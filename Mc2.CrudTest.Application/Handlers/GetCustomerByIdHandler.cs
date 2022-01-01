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
    public class GetCustomerByIdHandler:IRequestHandler<GetCustomerByIdQuery,CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw  new ArgumentNullException(nameof(customerRepository));

        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var obj = await _customerRepository.GetByIdAsync(cancellationToken, request.Id);
            if (obj == null) return new CustomerResponse();
            return new CustomerResponse()
            {
                Id = obj.Id,
                BankAccountNumber = obj.BankAccountNumber,
                DateOfBirth = obj.DateOfBirth,
                Email = obj.Email,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                PhoneNumber = obj.PhoneNumber
            };

        }
    }
}
