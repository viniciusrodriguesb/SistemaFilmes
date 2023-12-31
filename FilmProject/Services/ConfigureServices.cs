﻿using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FilmProject.Services
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<AvaliacaoService>();
        }
    }
}
