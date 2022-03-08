using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL;
using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.DAL.Repositories;
using GerenciadorCondominios.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectString = Configuration.GetConnectionString("DbSqlServer");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(sqlConnectString));
            //Informar a classe de usu�rio, a classe de fun��es/regras e onde ocorre o armazenamento.
            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<ApplicationContext>();

            //Adicionando servi�os de Autentica��o e Autoriza��o
            services.AddAuthentication();
            services.AddAuthorization();

            //M�todos de extens�o que criamos para configura��es
            services.ConfigurarRepositorios();
            services.ConfigurarCookies();
            services.ConfigurarNomeUsuario();
            services.ConfigurarSenhaUsuario();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
