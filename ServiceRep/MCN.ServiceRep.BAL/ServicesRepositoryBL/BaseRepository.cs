using MCN.ServiceRep.BAL.ContextModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL
{
    public abstract class BaseRepository
    {
        protected RepositoryContext repositoryContext;
        public BaseRepository(RepositoryContext repository)
        {
            repositoryContext = repository;
        }
    }
}
