using System;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions; 
using MCN.Infrastructure.BAL.Common; 
using MCN.ServiceRep.BAL.Common; 

namespace MCN.ServiceRep.DepencyInjuctionInfo {
    public class CommonBALRep
    {
       public CommonBALRep(IServiceCollection services)
       {
          try
          {
                services.AddTransient<IJDataTableDataBL, JDataTableDataBL>();
                services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                //services.AddTransient<IHttpRequestProcessorBase, HttpRequestProcessorBase>();
                //services.AddTransient<IResponseTextBL, ResponseTextBL>(); 
            }
            catch (Exception ex)
          {
              throw ex;
          }
       }
    } 
}
