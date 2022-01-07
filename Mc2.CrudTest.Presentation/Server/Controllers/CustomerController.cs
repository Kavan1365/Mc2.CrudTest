using Mc2.CrudTest.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Mc2.CrudTest.Domain.Generators;
using MediatR;
using System;
using Mc2.CrudTest.Application.Responses;
using Mc2.CrudTest.Application.Queries;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Commands;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator,ILogger<CustomerController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public async Task<CustomerResponse> Get(int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var customer =await _mediator.Send(query);
            return customer;
        }

        [HttpPost()]
        public async Task<string> Create(CustomerResponse dto)
        {
            var query = new CreateCustomerCommand(dto);
            var customer = await _mediator.Send(query);
            return customer;
        }

        [HttpPost("[action]")]
        public async Task<string> update(CustomerResponse dto)
        {
            var query = new UpdateCustomerCommand(dto);
            var customer = await _mediator.Send(query);
            return customer;
        }

        [HttpPost("[action]/{id}")]
        public async Task<string> Delete(int id)
        {
            var query = new DeleteCustomerCommand(id);
            var customer = await _mediator.Send(query);
            return customer;
        }
    }
}
