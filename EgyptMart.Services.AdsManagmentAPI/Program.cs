using EgyptMart.Services.AdsManagmentAPI.Data;
using EgyptMart.Services.AdsManagmentAPI.Extentions;
using EgyptMart.Services.AdsManagmentAPI.IRepository;
using EgyptMart.Services.AdsManagmentAPI.Repository;
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddAuthorizationExtentionService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
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

app.UseHttpsRedirection();

app.UseWhen(
    context => context.Request.Path.Value?.Contains("/api/store/v2", StringComparison.OrdinalIgnoreCase) == true,
    branch =>
    {
        branch.UseRateLimiter();
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
