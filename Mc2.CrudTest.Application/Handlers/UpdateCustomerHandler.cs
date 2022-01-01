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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw  new ArgumentNullException(nameof(customerRepository));

        }

        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
            
            
            var obj=  await _customerRepository.GetByIdAsync(cancellationToken,request.Customer.Id);
            if (obj==null)
            {
                return "The customer was not found";

            }

            obj.BankAccountNumber = request.Customer.BankAccountNumber;
            obj.DateOfBirth = request.Customer.DateOfBirth;
            obj.Email = request.Customer.Email;
            obj.FirstName = request.Customer.FirstName;
            obj.LastName = request.Customer.LastName;
            obj.PhoneNumber = request.Customer.PhoneNumber;
             await _customerRepository.UpdateAsync(obj, cancellationToken);
            return "mission accomplished";

        }
    }
}
