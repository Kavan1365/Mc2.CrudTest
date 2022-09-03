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
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IMediator mediator,ILogger<StoreController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        public async Task<StoreResponse> Get(int id)
        {
            var query = new GetStoreByIdQuery(id);
            var Store =await _mediator.Send(query);
            return Store;
        }

        [HttpPost()]
        public async Task<string> Create(StoreResponse dto)
        {
            var query = new CreateStoreCommand(dto);
            var Store = await _mediator.Send(query);
            return Store;
        }

        [HttpPost("[action]")]
        public async Task<string> update(StoreResponse dto)
        {
            var query = new UpdateStoreCommand(dto);
            var Store = await _mediator.Send(query);
            return Store;
        }

        [HttpPost("[action]/{id}")]
        public async Task<string> Delete(int id)
        {
            var query = new DeleteStoreCommand(id);
            var Store = await _mediator.Send(query);
            return Store;
        }
    }
}
