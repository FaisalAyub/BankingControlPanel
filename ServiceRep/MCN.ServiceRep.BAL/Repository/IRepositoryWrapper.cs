using OnlineApp.ServiceRep.BAL.UserRepositoryWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApp.ServiceRep.BAL.Repository
{
    public interface IRepositoryWrapper
    {
        IFormPageRepositoryWrapper FormPage { get; }
        IFormRepositoryWrapper Form { get; }
        IFormStatusRepositoryWrapper FormStatus { get; }
        IFieldOptionRepositoryWrapper FieldOption { get; }
        IFieldRepositoryWrapper Field { get; }
        IFieldDataRepositoryWrapper FieldData { get; }
        IApplicationDataWrapper ApplicationData { get; }
        IFieldDisplayRepositoryWrapper FieldDisplay { get; }
        IFieldLargeTextRepositoryWrapper FieldLargeText { get; }
        IFieldDataInputFormatRepositoryWrapper FieldDataInputFormat { get; }
        IFieldDataRegExRepositoryWrapper FieldDataRegEx { get; }
        IFieldUploadFileCategoryRepositoryWrapper FieldUploadFileCategory { get; }
        IFieldUploadFileTypeRepositoryWrapper FieldUploadFileType { get; }
        IFormPagePanelFieldRepositoryWrapper FormPagePanelField { get; }
        IFormPagePanelRepositoryWrapper FormPagePanel { get; }
        IFormRuleAssociationRepositoryWrapper FormRuleAssociation { get; }
        IFormRuleCreteriaRepositoryWrapper FormRuleCreteria { get; }
        IFormRuleRepositoryWrapper FormRule { get; }
        IUserRepositoryWrapper User { get; }
        IUserAuthtokenRepositoryWrapper UserAuthtoken { get; }
        IUserLoginTypeRepositoryWrapper UserLoginType { get; }
        IUserMultiFactorRepositoryWrapper UserMultiFactor { get; }
        IEmailLogRepositoryWrapper EmailLog { get; }
        IAdminOfficeRepositoryWrapper AdminOffice { get; }
        IProductModuleRepositoryWrapper ProductModule { get; }
        IAOProductModuleRepositoryWrapper AOProductModule { get; }
        IUserEntityTypeRepositoryWrapper UserEntityType { get; }
        IUserEntityRepositoryWrapper UserEntity { get; }
        ISecurityRoleRepositoryWrapper SecurityRole { get; }
        ISecurityEntityTypeRepositoryWrapper SecurityEntityType { get; }
        ISecurityRoleActionRepositoryWrapper SecurityRoleAction { get; }
        ISecurityRoleUserRepositoryWrapper SecurityRoleUser { get; }
        ISecurityCategoryRepositoryWrapper SecurityCategory { get; }
        ISecurityActionRepositoryWrapper SecurityAction { get; }
        IAOSecurityActionRepositoryWrapper AOSecurityAction { get; }
        IAOSecurityCategoryRepositoryWrapper AOSecurityCategory { get; }
        IAutoCodeNumberRepositoryWrapper AutoCodeNumber { get; }
        void Save();
    }
}
