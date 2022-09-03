using Mc2.CrudTest.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Queries
{
    public class GetStoreByIdQuery : IRequest<StoreResponse>
    {
        public int Id { get; set; }
        public GetStoreByIdQuery(int id) 
        {
            Id = id;
        
        }
    }
}
