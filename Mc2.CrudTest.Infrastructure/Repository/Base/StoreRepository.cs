using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Base;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Repository.Base
{
    public class StoreRepository : IStoreRepository
    {
        protected readonly CrudContext _dbContext;

        public StoreRepository(CrudContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        ///// for edite and read////
        public virtual IQueryable<Domain.Store> Table => _dbContext.Set<Domain.Store>().OrderByDescending(x => x.Id);
        /////for only read////
        public virtual IQueryable<Domain.Store> TableNoTracking => _dbContext.Set<Domain.Store>().AsNoTracking().OrderByDescending(x => x.Id);


        #region Async Method
        public virtual ValueTask<Domain.Store> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return _dbContext.Set<Domain.Store>().FindAsync(ids, cancellationToken);
        }
        public virtual async Task AddAsync(Domain.Store entity, CancellationToken cancellationToken, bool saveNow = true)
        {

            if (string.IsNullOrEmpty(entity.Title))
                throw new ArgumentException("is requrid Title", "Title");



            await _dbContext.Set<Domain.Store>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        } 
        public virtual async Task UpdateAsync(Domain.Store entity, CancellationToken cancellationToken, bool saveNow = true)
        {
             _dbContext.Set<Domain.Store>().Update(entity);
            if (saveNow)
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(Domain.Store entity, CancellationToken cancellationToken, bool saveNow = true)
        {
           


                _dbContext.Set<Domain.Store>().Remove(entity);

                if (saveNow)
                    await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



            #endregion






        }
        }
}
