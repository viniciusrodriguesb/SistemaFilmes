using FilmProject.Models;
using FilmProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco
//string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DbContextBase>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));


//Utiliza��o do banco em mem�ria
builder.Services.AddDbContext<DbContextBase>(options =>
                options.UseInMemoryDatabase("ApiDatabase"));

// Configura��o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders(new[] { "Content-Disposition" })
               );
});

// Configura��o de Cache em Mem�ria
builder.Services.AddMemoryCache();

// Configura��o do MVC
builder.Services.AddControllers();

// Configura��o do Swagger
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