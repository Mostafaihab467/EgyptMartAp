using EgyptMart.Services.ReportingAPI.Data;
using EgyptMart.Services.ReportingAPI.Extentions;
using EgyptMart.Services.ReportingAPI.IRepository;
using EgyptMart.Services.ReportingAPI.Repository;
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

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<ISupplierDashBoardrpository, SupplierDashBoardrpository>();
builder.Services.AddTransient<IWrapperRepository, WrapperRepository>();

builder.Services.AddAuthorizationExtentionService();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
