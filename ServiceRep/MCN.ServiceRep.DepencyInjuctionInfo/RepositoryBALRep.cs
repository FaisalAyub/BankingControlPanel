using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MCN.Infrastructure.BAL.Common;
////babar using MCN.ServiceRep.BAL.Base;
using MCN.ServiceRep.BAL.Common;
using MCN.ServiceRep.BAL.Repository;

namespace MCN.ServiceRep.DepencyInjuctionInfo {
    public class RepositoryBALRep
    {
       public RepositoryBALRep(IServiceCollection services, IConfiguration config)
       {
          try
          {
                new SqlContext(services, config);      
            }
          catch (Exception ex)
          {
              throw ex;
          }
       }
    } 
}
