using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Base
{
    public interface IStoreRepository
    {
        IQueryable<Store> Table { get; }
        IQueryable<Store> TableNoTracking { get; }
        ValueTask<Store> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        Task AddAsync(Store entity, CancellationToken cancellationToken, bool saveNow = true);
        Task UpdateAsync(Store entity, CancellationToken cancellationToken, bool saveNow = true);
        Task DeleteAsync(Store entity, CancellationToken cancellationToken, bool saveNow = true);
    }
}
