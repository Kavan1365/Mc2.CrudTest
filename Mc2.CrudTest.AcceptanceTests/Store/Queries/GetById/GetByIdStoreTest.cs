using Mc2.CrudTest.Application.Handlers;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Domain.Base;
using Mc2.CrudTest.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Store.Queries.GetById
{
   

    public class GetByIdStoreTest : CommandTestBase
    {
        private readonly IStoreRepository _repository;
        public GetByIdStoreTest()
        {
            _repository = new StoreRepository(_context);
        }

        [Fact]
        public async Task GetByGuidStore()
        {

            // arrange
            var sut = new GetStoreByIdHandler(_repository);

            // arrange

            var result = await sut.Handle(new GetStoreByIdQuery(1) {}, CancellationToken.None);


            // arrange
            var okResult = Assert.IsType<StoreResponse>(result);
            Assert.NotNull(okResult);

        }
    }
}
