using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.Extentions;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.ProviderServices;
using EgyptMart.Services.Auth.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Configs
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));



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
builder.Services.AddTransient<IHashPasswordService, HashPasswordService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IAccountsRepository, AccountsRepository>();
builder.Services.AddTransient<IVerifyRepository, VerifyRepository>();
builder.Services.AddTransient<IRecoveryRepository, RecoveryRepository>();
builder.Services.AddTransient<IRegisterRepository, RegisterRepository>();
builder.Services.AddTransient<IAuthLupsRepository, AuthLupsRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();

builder.Services.AddAuthorizationExtentionService(builder.Configuration);

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

app.UseHttpsRedirection();




app.UseRateLimiter();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
