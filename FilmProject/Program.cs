using FilmProject;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var startup = new Startup(env);
startup.ConfigureServices(builder.Services);

// Construção do aplicativo
var app = builder.Build();  

// Configuração Middleware
startup.Configure(app);

app.Run();