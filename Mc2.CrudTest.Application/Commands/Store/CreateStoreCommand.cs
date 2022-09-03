﻿using Mc2.CrudTest.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands
{
    public class CreateStoreCommand: IRequest<string>
    {
        public StoreResponse Store { get; set; }
        public CreateStoreCommand(StoreResponse Store)
        {
            this.Store = Store;

        }
    }
}
