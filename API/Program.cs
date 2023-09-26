using AutoMapper;
using ChefDigital.Domain.Interfaces.Generics;
using ChefDigital.Entities.Entities;
using ChefDigital.Infra.Configuration;
using ChefDigital.Infra.Repository.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ChefDigital.API.Token;
using ChefDigital.Domain.Interfaces;
using ChefDigital.Domain.Service.Client;
using ChefDigital.Infra.Repository.Repositories;
using ChefDigitalAPI.Application.Client;
using ChefDigitalAPI.Application.Client.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ConfigServices
builder.Services.AddDbContext<ContextBase>(options =>
              options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

//Application CLient
builder.Services.AddScoped<IClientCreateAppService, ClientCreateAppService>();
builder.Services.AddScoped<IClientUpdateAppService, ClientUpdateAppService>();
builder.Services.AddScoped<IClientListAppService, ClientListAppService>();
builder.Services.AddScoped<IClientDisableAppService, ClientDisableAppService>();

//Domain Service Client
builder.Services.AddScoped<IClientCreateService, ClientCreateService>();
builder.Services.AddScoped<IClientUpdateService, ClientUpdateService>();
builder.Services.AddScoped<IClientListService, ClientListService>();
builder.Services.AddScoped<IClientDisableService, ClientDisableService>();

// SERVIÇO DOMINIO
//builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Securiry.Bearer",
              ValidAudience = "Teste.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    //cfg.CreateMap<MessageViewModel, Message>();
    //cfg.CreateMap<Message, MessageViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var urlDev = "https://dominiodocliente.com.br";
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";

//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

var devClient = "http://localhost:7186";
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader().WithOrigins(devClient));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
