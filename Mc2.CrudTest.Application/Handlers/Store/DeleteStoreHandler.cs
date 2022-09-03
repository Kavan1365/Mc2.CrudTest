using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Domain;
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
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, string>
    {
        private readonly IStoreRepository _StoreRepository;

        public DeleteStoreHandler(IStoreRepository StoreRepository)
        {
            _StoreRepository = StoreRepository ?? throw  new ArgumentNullException(nameof(StoreRepository));

        }

        public async Task<string> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
          var obj=  await _StoreRepository.GetByIdAsync(cancellationToken,request.Id);
            if (obj == null)
            {
                return "The Store was not found";

            }

            await _StoreRepository.DeleteAsync(obj, cancellationToken);
            return "mission accomplished";
        }
    }
}
