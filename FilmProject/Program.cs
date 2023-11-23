using FilmProject.Models;
using FilmProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco
//string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DbContextBase>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));


//Utilização do banco em memória
builder.Services.AddDbContext<DbContextBase>(options =>
                options.UseInMemoryDatabase("ApiDatabase"));

// Configuração CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders(new[] { "Content-Disposition" })
               );
});

// Configuração de Cache em Memória
builder.Services.AddMemoryCache();

// Configuração do MVC
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Filmes API", Version = "v1" });
});

builder.Services.AddServices();

var app = builder.Build();

app.UseCors("AllowAny");

app.UseRouting();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes API");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();