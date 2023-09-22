using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChefDigital.Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetEntityById(Guid id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> condition);
        Task<List<T>> List();
    }
}
