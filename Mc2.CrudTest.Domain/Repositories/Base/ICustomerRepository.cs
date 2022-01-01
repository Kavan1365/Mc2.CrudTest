using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Base
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Table { get; }
        IQueryable<Customer> TableNoTracking { get; }
        ValueTask<Customer> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
        Task AddAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true);
        Task UpdateAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true);
        Task DeleteAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true);
    }
}
