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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw  new ArgumentNullException(nameof(customerRepository));

        }

        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
          var obj=  await _customerRepository.GetByIdAsync(cancellationToken,request.Id);
            if (obj == null)
            {
                return "The customer was not found";

            }

            await _customerRepository.DeleteAsync(obj, cancellationToken);
            return "mission accomplished";
        }
    }
}
