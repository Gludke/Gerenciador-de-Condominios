using GerenciadorCondominios.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Interfaces
{
    public interface IUsuarioRepositorio : IRepoGenerico<Usuario>
    {
        int VerificaSeExisteRegistro();
        Task LogarUsuario(Usuario usuario, bool lembrar);//se os dados devem ser lembrados

        //'IdentityResult' é o tipo de retorno do Identity, para sabermos o que status da criação.
        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);

        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);
    }
}
