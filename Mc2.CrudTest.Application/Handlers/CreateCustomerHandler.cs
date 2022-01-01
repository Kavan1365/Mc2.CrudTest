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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw  new ArgumentNullException(nameof(customerRepository));

        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            CustomerValidator validator = new CustomerValidator();

            ValidationResult results = validator.Validate(request.Customer);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    return ("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            var dto= new Customer()
            {
                Id = request.Customer.Id,
                BankAccountNumber = request.Customer.BankAccountNumber,
                DateOfBirth = request.Customer.DateOfBirth,
                Email = request.Customer.Email,
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                PhoneNumber = request.Customer.PhoneNumber
            };
             await _customerRepository.AddAsync(dto,cancellationToken);
            request.Customer.Id = dto.Id;
            return "mission accomplished";

        }
    }
}
