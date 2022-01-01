using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Data
{
    public class CrudContextSeed
    {
        public static async Task  SeedAsync(CrudContext crudContext,ILoggerFactory loggerFactory,int? retry = 0) 
        {

            int retryForAvailability = retry.Value;
            try
            {
                crudContext.Database.EnsureCreated();
                ///seek///

            }
            catch (Exception e)
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<CrudContextSeed>();
                log.LogError(e.Message);
                await SeedAsync(crudContext, loggerFactory, retryForAvailability);

            }
        }
    }
}
