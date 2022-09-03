using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Domain.Base;
using MediatR;
using Store.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Handlers
{
    public class GetStoreByIdHandler:IRequestHandler<GetStoreByIdQuery,StoreResponse>
    {
        private readonly IStoreRepository _StoreRepository;

        public GetStoreByIdHandler(IStoreRepository StoreRepository)
        {
            _StoreRepository = StoreRepository ?? throw  new ArgumentNullException(nameof(StoreRepository));

        }

        public async Task<StoreResponse> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _StoreRepository.GetByIdAsync(cancellationToken, request.Id);
            if (obj == null) return new StoreResponse();
            return new StoreResponse()
            {
                Id = obj.Id,
                Title = obj.Title,
                Address = obj.Address,
            };

        }
    }
}
