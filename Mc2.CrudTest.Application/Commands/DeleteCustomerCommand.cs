using Mc2.CrudTest.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteCustomerCommand(int id)
        {
            Id = id;

        }
    }
}
