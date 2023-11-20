using FilmProject.Models;
using FilmProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace FilmProject
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do banco
            string mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbContextBase>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            // Configuração CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", builder => builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .WithExposedHeaders(new[] { "Content-Disposition" })
                           );
            });

            // Configuração de Cache em Memória
            services.AddMemoryCache();

            // Configuração do MVC
            services.AddControllers();

            // Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Filmes API", Version = "v1" });
            });

            // Adição de Serviços Customizados
            services.AddServices();
        }

        public void Configure(WebApplication app)
        {
            // Uso do Middleware Swagger
            app.UseSwagger();

            // Configuração do Middleware CORS
            app.UseCors("AllowAny");

            // Configuração do Middleware Routing
            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes API");
            });

            // Configuração de Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowAny");
            });
        }
    }
}
