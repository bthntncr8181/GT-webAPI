using FluentValidation;
using GTBack.Core.Entities;
using GTBack.Core.Repositories;
using GTBack.Core.Services;
using GTBack.Core.UnitOfWorks;
using GTBack.Repository;
using GTBack.Repository.Repositories;

using GTBack.Repository.UnitOfWorks;
using GTBack.Service.Configurations;
using GTBack.Service.Mapping;
using GTBack.Service.Services;
using GTBack.Service.Utilities.Jwt;
using GTBack.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoThere API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddScoped<RefreshTokenRepository>();
builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
builder.Services.AddScoped(typeof(IJwtTokenService), typeof(JwtTokenService));
builder.Services.AddScoped(typeof(IRefreshTokenService), typeof(RefreshTokenService));
builder.Services.AddAppConfiguration(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IEventService), typeof(EventService));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.LoadValidators();

var appConfig = builder.Configuration.Get<GoThereAppConfig>();


SqlConnectionStringBuilder mySql = new SqlConnectionStringBuilder();
mySql.DataSource = "database-1.c8fdlf1gvqc2.us-east-1.rds.amazonaws.com"; 
mySql.UserID = "admin";            
mySql.Password = "Bthntncr81.";     
mySql.InitialCatalog = "database-1";


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(mySql.ConnectionString, option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });


});
var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoThere API v1");
    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
});
app.UseAuthentication();


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
