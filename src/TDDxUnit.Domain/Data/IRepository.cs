using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDDxUnit.Domain.Data.Repositories
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        T Get(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}