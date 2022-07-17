using OnlineApp.Infrastructure.BAL.Repository;
using OnlineApp.ServiceRep.BAL.ContextModel;
using OnlineApp.ServiceRep.BAL.Repository;
using OnlineApp.ServiceRep.BAL.UserRepositoryWrapper;

namespace OnlineApp.Infrastructure.BAL.UserRepositoryWrapper
{
    public class FieldRepositoryWrapper : RepositoryBase<OnlineApp.ServiceRep.BAL.ContextModel.Field>, IFieldRepositoryWrapper
    {
        public FieldRepositoryWrapper(RepositoryContext repositoryContext)
              : base(repositoryContext)
        {

        }
    }

    public class FieldDataRepositoryWrapper : RepositoryBase<FieldData>, IFieldDataRepositoryWrapper
    {
        public FieldDataRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class ApplicationDataWrapper : RepositoryBase<ApplicationData>, IApplicationDataWrapper
    {
        public ApplicationDataWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldDataInputFormatRepositoryWrapper : RepositoryBase<FieldDataInputFormat>, IFieldDataInputFormatRepositoryWrapper
    {
        public FieldDataInputFormatRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldDataRegExRepositoryWrapper : RepositoryBase<FieldDataRegEx>, IFieldDataRegExRepositoryWrapper
    {
        public FieldDataRegExRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldDisplayRepositoryWrapper : RepositoryBase<FieldDisplay>, IFieldDisplayRepositoryWrapper
    {
        public FieldDisplayRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldLargeTextRepositoryWrapper : RepositoryBase<FieldLargeText>, IFieldLargeTextRepositoryWrapper
    {
        public FieldLargeTextRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldUploadFileCategoryRepositoryWrapper : RepositoryBase<FieldUploadFileCategory>, IFieldUploadFileCategoryRepositoryWrapper
    {
        public FieldUploadFileCategoryRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }

    public class FieldUploadFileTypeRepositoryWrapper : RepositoryBase<FieldUploadFileType>, IFieldUploadFileTypeRepositoryWrapper
    {
        public FieldUploadFileTypeRepositoryWrapper(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
