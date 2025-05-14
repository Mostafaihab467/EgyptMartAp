using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.Extentions;
using EgyptMart.Services.CMSAPI.Helper;
using EgyptMart.Services.CMSAPI.Interfaces.Helper;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Logger;
using EgyptMart.Services.CMSAPI.Repository;
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

// Hello world servicexx

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<ICMSListRepository, CMSListRepository>();
builder.Services.AddScoped<IWidgets_SocialMediaRepository, Widgets_SocialMedia_Repository>();
builder.Services.AddScoped<IHelperSerivce, HelperService>();
builder.Services.AddScoped<IWidgets_HeaderMenu_Repository, Widgets_HeaderMenu_Repository>();
builder.Services.AddScoped<IProductYouMayLikeTRepository, ProductYouMayLikeTRepository>();
builder.Services.AddScoped<IStoreFrontWidgetsRepository, StoreFrontWidgetsRepository>();
builder.Services.AddScoped<ITransalationRepository, TransalationRepository>();
builder.Services.AddScoped<ISubscribtionListRepository, SubscribtionListRepository>();
builder.Services.AddScoped<IFooterLinksRepository, FooterLinksRepository>();
builder.Services.AddScoped<IWidgets_FixedPagesRepository, Widgets_FixedPagesRepository>();
builder.Services.AddScoped<ILubsRepository, LubsRepository>();

builder.Services.AddAuthorizationExtentionService(builder.Configuration);




builder.Logging.AddProvider(new FileLoggerProvider("./CategoryService.log"));


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
