using System.Text;
using EgyptMart.Services.ReportingAPI.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EgyptMart.Services.ReportingAPI.Extentions
{
    public static class AddAuthorizationExtention
    {
        public static IServiceCollection AddAuthorizationExtentionService(this IServiceCollection services)
        {
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
                    Title = "EgyptMart Reporting API",
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
                        Array.Empty<string>()
                    }
                });
            });


            services.AddAuthorization();


            return services;
        }

    }
}



