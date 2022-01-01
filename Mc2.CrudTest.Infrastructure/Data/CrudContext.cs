using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

      
    }
}
