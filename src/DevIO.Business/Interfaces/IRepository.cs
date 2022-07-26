using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface  IRepository<T> : IDisposable where T : Entity
    {
        Task AdicionarAsync(T obj);
        Task<IEnumerable<T>> ListarTodosAync();
        Task AtualizarAsync(T obj);
        Task<T> ObterPorIdAsync(Guid id);
        Task Remover(Guid id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();

    }
}
