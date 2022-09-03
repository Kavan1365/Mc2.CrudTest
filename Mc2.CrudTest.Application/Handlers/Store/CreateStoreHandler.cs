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
    public class CreateStoreHandler : IRequestHandler<CreateStoreCommand, string>
    {
        private readonly IStoreRepository _StoreRepository;

        public CreateStoreHandler(IStoreRepository StoreRepository)
        {
            _StoreRepository = StoreRepository ?? throw  new ArgumentNullException(nameof(StoreRepository));

        }

        public async Task<string> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
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

            var dto= new Domain.Store()
            {
                Id = request.Store.Id,
                Address = request.Store.Address,
                Title = request.Store.Title,
            };
             await _StoreRepository.AddAsync(dto,cancellationToken);
            request.Store.Id = dto.Id;
            return "mission accomplished";

        }
    }
}
