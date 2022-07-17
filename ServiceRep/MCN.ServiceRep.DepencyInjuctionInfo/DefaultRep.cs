using System;
using Microsoft.Extensions.DependencyInjection;
namespace MCN.ServiceRep.DepencyInjuctionInfo
{
    public class DefaultRep
    {  
        public void SetInjuctions(IServiceCollection services)
        {
            try
            {
                //new DTOEntitiesInjections(services);
                //new CoreEntitiesInjections(services);               
                new CommonBALRep(services);
                new RegisterRepositoryExtension(services);              
            }
            catch (Exception Exc)
            {
                throw Exc;
            }            
        }
    }
}
