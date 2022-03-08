using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL
{
    //Classe criada para centralizar a configuração das injeções dos repositórios
    //precisa do sufixo 'Extension', pois extende Startup
    public static class ConfigurarRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}
