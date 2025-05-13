using EgyptMart.Services.ProductsAPI.Data;
using EgyptMart.Services.ProductsAPI.Extentions;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.loggerError;
using EgyptMart.Services.ProductsAPI.Middleware;
using EgyptMart.Services.ProductsAPI.Repository;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBMasterContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MasterConnection"));
}
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policyBuilder =>
    {
        policyBuilder
            .WithOrigins("https://adminportal.egyptbigmart.com", "https://egyptbigmart.com", "https://supplierportal.egyptbigmart.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new FileLoggerProvider("logs/test.log"));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorizationExtentionService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCorsPolicy");
//app.UseCors(conf =>
//{
//    conf.AllowAnyOrigin()
//    .AllowAnyHeader()
//    .AllowAnyMethod();
//});

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings = { [".glb"] = "model/gltf-binary" }
    }
});

app.UseHttpsRedirection();

app.UseWhen(
    context => context.Request.Path.Value?.Contains("/api/store/v2", StringComparison.OrdinalIgnoreCase) == true,
    branch =>
    {
        branch.UseRateLimiter();
    });

app.UseMiddleware<UnVerifiedMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
