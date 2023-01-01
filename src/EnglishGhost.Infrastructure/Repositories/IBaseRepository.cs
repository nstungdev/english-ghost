using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishGhost.Infrastructure.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWithCondition(Func<T, bool> predicate);
    }
}
