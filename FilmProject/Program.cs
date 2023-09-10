using FilmProject;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var startup = new Startup(env);
startup.ConfigureServices(builder.Services);

// Constru��o do aplicativo
var app = builder.Build();  

// Configura��o Middleware
startup.Configure(app);

app.Run();