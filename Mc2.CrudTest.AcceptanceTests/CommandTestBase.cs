using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class CommandTestBase : IDisposable
    {
        protected readonly CrudContext _context;


        public CommandTestBase()
        {
            var options = new DbContextOptionsBuilder<CrudContext>()
                 .UseInMemoryDatabase(Guid.NewGuid().ToString())
                 .Options;

            _context = new CrudContext(options);

            #region Store1
            _context.Add(new Domain.Store() { Id = 1, Address = "Address",  Title = "Store1" });

            #endregion

            #region User
            _context.Add(new Customer() { Id = 1, BankAccountNumber ="123456", Email = "ahmadi.kavan@yahoo.com",DateOfBirth=DateTime.Now,FirstName="kavan",LastName="Ahmadi" });

            #endregion

            _context.SaveChanges();


        }
        public void Dispose()
        {
        }
    }
}
