using System.Text;
using System.Threading.RateLimiting;
using EgyptMart.Services.ProductsAPI.Classes;

//using EgyptMart.Services.ProductsAPI.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EgyptMart.Services.ProductsAPI.Extentions
{
    public static class AddAuthorizationExtention
    {
        public static IServiceCollection AddAuthorizationExtentionService(this IServiceCollection services, IConfiguration config)
        {



            services.AddHttpContextAccessor();


            var rateLimiterSettings = new RateLimiterOptions();
            config.GetSection("RateLimiter").Bind(rateLimiterSettings);

            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = 429;


                options.AddPolicy("AllRate", opt =>
                {
                    return RateLimitPartition.GetFixedWindowLimiter(
                        opt.Request.Path.ToString().ToLowerInvariant(),
                        _ => new FixedWindowRateLimiterOptions()
                        {
                            PermitLimit = rateLimiterSettings.Global.PermitRequests,
                            Window = TimeSpan.FromMinutes(rateLimiterSettings.Global.InMinutes),
                            QueueLimit = rateLimiterSettings.Global.Queue
                        });
                });

                options.GlobalLimiter =
                    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                        RateLimitPartition.GetFixedWindowLimiter(
                           httpContext.Connection.RemoteIpAddress?.ToString() ?? httpContext.Request.Headers["X-Forward-For"].ToString(),
                            _ => new FixedWindowRateLimiterOptions
                            {
                                PermitLimit = rateLimiterSettings.Ip.PermitRequests,
                                Window = TimeSpan.FromMinutes(rateLimiterSettings.Ip.InMinutes),
                                QueueLimit = rateLimiterSettings.Ip.Queue
                            }));


            });




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,  // Ensures that the token's expiration is validated
                        ClockSkew = TimeSpan.Zero, // Optional: Removes any clock skew (grace period) for token expiration validation
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyStores.JWT_SECRET_KEY)),
                        ValidIssuer = KeyStores.JWT_Issuer,
                        ValidAudience = KeyStores.JWT_Audience
                    };



                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // Handle failed authentication (e.g., expired token)
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                // Handle expired token scenario
                                context.Response.Headers.Append("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });




            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EgyptMart Products API",
                    Version = "v1"
                });

                // Add JWT Authentication to Swagger
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer {your JWT token}' below. Example: 'Bearer abc123...'"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                                    },
                                    new string[] {}
                                }
                    });
            });





            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("VerifiedOnly", o =>
                {
                    o.RequireClaim("isVerified", "True");
                });
            });


            return services;
        }

    }
}



