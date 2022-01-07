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

namespace Store.Infrastructure.Repository.Base
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly CrudContext _dbContext;

        public CustomerRepository(CrudContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        ///// for edite and read////
        public virtual IQueryable<Customer> Table => _dbContext.Set<Customer>().OrderByDescending(x => x.Id);
        /////for only read////
        public virtual IQueryable<Customer> TableNoTracking => _dbContext.Set<Customer>().AsNoTracking().OrderByDescending(x => x.Id);


        #region Async Method
        public virtual ValueTask<Customer> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            return _dbContext.Set<Customer>().FindAsync(ids, cancellationToken);
        }
        public virtual async Task AddAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true)
        {

            if (string.IsNullOrEmpty(entity.FirstName))
                throw new ArgumentException("is requrid Firstname", "FirstName");

            if (string.IsNullOrEmpty(entity.LastName))
                throw new ArgumentException("is requrid lastname", "LastName");
            
            if (string.IsNullOrEmpty(entity.Email))
                throw new ArgumentException("is requrid Email", "Email");

           

            var check = _dbContext.Set<Customer>().Any(z => z.Email == entity.Email);
            if (check)
                throw new ArgumentException("The email is duplicate", "Email");


            await _dbContext.Set<Customer>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        } 
        public virtual async Task UpdateAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true)
        {
             _dbContext.Set<Customer>().Update(entity);
            if (saveNow)
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(Customer entity, CancellationToken cancellationToken, bool saveNow = true)
        {
           


                _dbContext.Set<Customer>().Remove(entity);

                if (saveNow)
                    await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);



            #endregion






        }
        }
}
