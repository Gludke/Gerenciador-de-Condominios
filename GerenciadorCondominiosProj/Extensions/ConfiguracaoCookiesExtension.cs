using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Extensions
{
    //precisa do sufixo 'Extension', pois extende Startup
    public static class ConfiguracaoCookiesExtension
    {
        public static void ConfigurarCookies(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options => {
                options.Cookie.Name = "IdentityCookie";//nome do cookie
                options.Cookie.HttpOnly = true;//cookie pode ser acessado via scripts pelo client-side
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);//60 min de duração
                options.LoginPath = "/Usuarios/Login"; //Rota de login
            });
        }
    }
}
