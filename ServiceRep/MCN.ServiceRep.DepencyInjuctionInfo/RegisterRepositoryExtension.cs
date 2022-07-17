using System;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL;
using Microsoft.Extensions.DependencyInjection; 

namespace MCN.ServiceRep.DepencyInjuctionInfo
{
    public class RegisterRepositoryExtension
    {
        public RegisterRepositoryExtension(IServiceCollection services)
        {
            try
            { 
                services.AddScoped<IUserRepositoryBL, UserRepositoryBL>();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
