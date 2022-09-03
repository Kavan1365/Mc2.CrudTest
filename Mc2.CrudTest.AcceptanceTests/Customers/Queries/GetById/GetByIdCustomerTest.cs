using Mc2.CrudTest.Application.Handlers;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Domain.Base;
using Mc2.CrudTest.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Queries.GetById
{
   

    public class GetByIdCustomerTest : CommandTestBase
    {
        private readonly ICustomerRepository _repository;
        public GetByIdCustomerTest()
        {
            _repository = new CustomerRepository(_context);
        }

        [Fact]
        public async Task GetByGuidCustomer()
        {

            // arrange
            var sut = new GetCustomerByIdHandler(_repository);

            // arrange

            var result = await sut.Handle(new GetCustomerByIdQuery(1) {}, CancellationToken.None);


            // arrange
            var okResult = Assert.IsType<CustomerResponse>(result);
            Assert.NotNull(okResult);

        }
    }
}
