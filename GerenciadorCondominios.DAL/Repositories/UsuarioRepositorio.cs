using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositories
{
    public class UsuarioRepositorio : RepoGenerico<Usuario>, IUsuarioRepositorio
    {
        #region "PROPERTIES"

        private readonly ApplicationContext _context;
        //Atributo para gerenciar as operações do usuário:
        private readonly UserManager<Usuario> _gerenciadorUsuario;
        //Atributo para gerenciar o LOGIN:
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        #endregion

        #region "CONSTRUCTORS"

        public UsuarioRepositorio(ApplicationContext applicationContext,
            UserManager<Usuario> gerenciadorUsuario,
            SignInManager<Usuario> gerenciadorLogin
            ) : base(applicationContext)
        {
            _context = applicationContext;
            _gerenciadorUsuario = gerenciadorUsuario;
            _gerenciadorLogin = gerenciadorLogin;
        }

        #endregion

        #region "METHODS"

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuario.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuario.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int VerificaSeExisteRegistro()
        {
            try
            {
                return _context.Usuarios.Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
