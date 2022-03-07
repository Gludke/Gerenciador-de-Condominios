using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositories
{
    public class RepoGenerico<TEntity> : IRepoGenerico<TEntity> where TEntity : class
    {
        #region "PROPERTIES"

        private readonly ApplicationContext _applicationContext;
        private readonly DbSet<TEntity> _dbContext;

        #endregion

        #region "CONSTRUCTORS"

        public RepoGenerico(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbContext = _applicationContext.Set<TEntity>();
        }

        #endregion

        #region "METHODS"

        public async Task Atualizar(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _dbContext.Remove(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id nulo");

            try
            {
                var entity = await PegarPorId(id);
                _dbContext.Remove(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Id nulo");

            try
            {
                var entity = await PegarPorId(id);
                _dbContext.Remove(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Inserir(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
             
            try
            {
                await _dbContext.AddAsync(entity);
                await _applicationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> PegarPorId(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id é nulo");

            try
            {
                return await _dbContext.FindAsync(id);//Necessário passar o ID do objeto
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> PegarPorId(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("O id é nulo ou vazio");

            try
            {
                return await _dbContext.FindAsync(id);//Necessário passar o ID do objeto
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> PegarTodos()
        {
            try
            {
                return await _dbContext.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
