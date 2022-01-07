using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Base;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Repository.Base;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests
    {


        [Fact]
        public async void CreateCustomerValid_ReturnSuccess()
        {
            var options = new DbContextOptionsBuilder<CrudContext>()
                        .UseSqlServer("Data Source=.;Initial Catalog=cruddb;Integrated Security=true")
                        .Options;
            using (var context = new CrudContext(options))
            {
                var rep = new CustomerRepository(context);
                Assert.NotNull(rep);

                var customer = new Customer()
                {
                    FirstName = "kavan",
                    LastName = "ahmadi",
                    BankAccountNumber = "12334",
                    DateOfBirth = DateTime.Now,
                    Email = "ahmadi.kavan@yahoo.com",
                    PhoneNumber = "09187708317"

                };

                /////if is check null and empty Email and check duplicate Email

                await Assert.ThrowsAsync<ArgumentException>("Email", () => rep.AddAsync(customer, System.Threading.CancellationToken.None));


                /////if get by Id 

                var result = await rep.GetByIdAsync(System.Threading.CancellationToken.None, 1);

                Assert.NotNull(result);

                Assert.Equal(1,result.Id);
                
            

            }

        }
    }
}
