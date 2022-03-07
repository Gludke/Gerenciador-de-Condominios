using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public UsuarioRepositorio(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        #endregion

        #region "METHODS"

        public Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            
            throw new NotImplementedException();
        }

        public Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            throw new NotImplementedException();
        }

        public Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            throw new NotImplementedException();
        }

        public int VerificaSeExisteRegistro()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
