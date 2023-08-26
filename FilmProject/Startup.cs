using FilmProject.Models;
using FilmProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FilmProject
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders(new[] { "Content-Disposition" })
                );
            });

            services.AddMemoryCache();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Filmes API", Version = "v1" });
            });

            services.AddDbContext<DbContextBase>(options =>
                options.UseInMemoryDatabase("ApiDatabase"));

            services.AddScoped<UsuarioService>();
        }

        public void Configure(WebApplication app)
        {
            app.UseSwagger();
            app.UseRouting();

            // Ativar a UI do Swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
