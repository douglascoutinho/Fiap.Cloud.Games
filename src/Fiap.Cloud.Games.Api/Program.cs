using Fiap.Cloud.Games.Api.Services.IoC;
using Fiap.Cloud.Games.Infra.Data.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var caminhoBancoLocal = Directory.GetCurrentDirectory().Replace("Fiap.Cloud.Games.Api", "Fiap.Cloud.Games.Infra");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?.Replace("{AppDir}",$"{caminhoBancoLocal}");

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(connectionString));

  
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
  var generalInfo = new
  {
    Title = "Api - Fiap Cloud Games",
    Description = "Api para gerenciamento do dominio cloud games.",
    Contact = new Microsoft.OpenApi.Models.OpenApiContact
    {
      Name = "Time Fiap",
      Email = "timefiap@fiap.com.br"
    }
  };

  // Definição da Versão 1 
  options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
  {
    Title = generalInfo.Title,
    Version = "v1",
    Description = generalInfo.Description,
    Contact = generalInfo.Contact
  });

  // Definição da Versão 2 
  options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
  {
    Title = generalInfo.Title,
    Version = "v2",
    Description = generalInfo.Description,
    Contact = generalInfo.Contact
  });
});

#region [JWT] 
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
  options.RequireHttpsMetadata = false;
  options.SaveToken = true;
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = jwtIssuer,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
  };
});

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.RegisterDependencies(builder.Configuration);
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    // Cria os seletores de versão no topo da página do Swagger 
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api - Fiap Cloud Games v1");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "Api - Fiap Cloud Games v2");
  });
}

app.UseHttpsRedirection(); // Adicionado boa prática para APIs locais
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
