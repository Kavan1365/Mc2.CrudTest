using FluentValidation.Results;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Application.Validation;
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
    public class UpdateStoreHandler : IRequestHandler<UpdateStoreCommand, string>
    {
        private readonly IStoreRepository _StoreRepository;

        public UpdateStoreHandler(IStoreRepository StoreRepository)
        {
            _StoreRepository = StoreRepository ?? throw  new ArgumentNullException(nameof(StoreRepository));

        }

        public async Task<string> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            StoreValidator validator = new StoreValidator();

            ValidationResult results = validator.Validate(request.Store);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return ("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            
            
            var obj=  await _StoreRepository.GetByIdAsync(cancellationToken,request.Store.Id);
            if (obj==null)
            {
                return "The Store was not found";

            }

            obj.Title = request.Store.Title;
            obj.Address = request.Store.Address;
             await _StoreRepository.UpdateAsync(obj, cancellationToken);
            return "mission accomplished";

        }
    }
}
