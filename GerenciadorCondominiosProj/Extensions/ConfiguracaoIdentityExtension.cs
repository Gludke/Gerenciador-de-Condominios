using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Extensions
{
    //precisa do sufixo 'Extension', pois extende Startup
    public static class ConfiguracaoIdentityExtension
    {
        //Método que configura o nome dos usuários
        public static void ConfigurarNomeUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options => {
                //Definindo quais caracteres são aceitos no email e nome do usuário
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                //Definindo e-mails como únicos no BD
                options.User.RequireUniqueEmail = true;
            });
        }
        
        public static void ConfigurarSenhaUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options => {
                //Definindo regras da senha
                options.Password.RequireDigit = true;//letras
                options.Password.RequireLowercase = false;//Maiúsculas
                options.Password.RequireUppercase = false;//Minúsculas
                options.Password.RequireNonAlphanumeric = false;//Caracteres especiais
                options.Password.RequiredLength = 4;//Length mínimo
                options.Password.RequiredUniqueChars = 0;//pode repetir caracteres
            });
        }
    }
}
