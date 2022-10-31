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
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<PlaceRepository>();
builder.Services.AddScoped<AttributesRepository>();
builder.Services.AddScoped<RefreshTokenRepository>();
builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
builder.Services.AddScoped(typeof(IJwtTokenService), typeof(JwtTokenService));
builder.Services.AddScoped(typeof(IPlaceService), typeof(PlaceService));
builder.Services.AddScoped(typeof(IRefreshTokenService), typeof(RefreshTokenService));
builder.Services.AddAppConfiguration(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.LoadValidators();

var appConfig = builder.Configuration.Get<GoThereAppConfig>();




builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });


});
var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}); app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
