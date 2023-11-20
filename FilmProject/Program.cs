using FilmProject;

var builder = WebApplication.CreateBuilder(args);

var conf = builder.Configuration;
var env = builder.Environment;
var startup = new Startup(conf, env);
startup.ConfigureServices(builder.Services);

// Constru��o do aplicativo
var app = builder.Build();

// Configura��o Middleware
startup.Configure(app);

app.Run();