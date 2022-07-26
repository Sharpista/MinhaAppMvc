using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new() //indica que eu posso dar um new nessa classe
    {
        protected readonly DevIOContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(DevIOContext context)
        {
            Db = context;
            DbSet = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<T> ObterPorIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> ListarTodosAync()
        {
           return await DbSet.ToListAsync();
        }

        public virtual async Task AdicionarAsync(T obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
        }

        public virtual async Task AtualizarAsync(T obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public  async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            //evitar qualquer tipo de null exception reference
            Db?.Dispose();
        }
    }
}
