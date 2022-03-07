using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Interfaces
{
    public interface IRepoGenerico<TEntity> where TEntity: class
    {
        Task<IEnumerable<TEntity>> PegarTodos();
        Task<TEntity> PegarPorId(int id);
        Task<TEntity> PegarPorId(string id);
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Excluir(TEntity entity);
        Task Excluir(int id);
        Task Excluir(string id);
    }
}
