using OnlineApp.ServiceRep.BAL.ContextModel;
using OnlineApp.ServiceRep.BAL.Repository;

namespace OnlineApp.ServiceRep.BAL.UserRepositoryWrapper
{
    public interface IFieldDataRepositoryWrapper : IRepositoryBase<FieldData>
    {
    }
    public interface IApplicationDataWrapper : IRepositoryBase<ApplicationData>
    {
    }

}
