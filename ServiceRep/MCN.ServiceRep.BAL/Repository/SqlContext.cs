using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.Common;
using System;

namespace MCN.ServiceRep.BAL.Repository
{
    public class SqlContext
    {
        public SqlContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(config.GetConnectionString(RepositoryConstants._ConStr), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(19), null);
            }));
        }
    }
}
