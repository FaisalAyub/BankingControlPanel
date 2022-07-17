
using System;
using System.Reflection;

namespace MCN.Infrastructure.BAL.Common
{
    public class Modification
    {
        public static void ModifiedValues<EntityObject>(EntityObject Obj, bool CodeExists)
        {
            try
            {
                Type type = Obj.GetType();
                PropertyInfo propertyInfo = type.GetProperty("UpdatedOn", BindingFlags.Instance | BindingFlags.Public, null, typeof(DateTime), new Type[0], null);
                propertyInfo.SetValue(Obj, DateTime.Now, null);
                propertyInfo = type.GetProperty("UpdatedBy", BindingFlags.Instance | BindingFlags.Public, null, typeof(string), new Type[0], null);
                propertyInfo.SetValue(Obj, /*user.UserID*/ null);
                if (CodeExists == false)
                {
                    propertyInfo = type.GetProperty("CreatedOn", BindingFlags.Instance | BindingFlags.Public, null, typeof(DateTime), new Type[0], null);
                    propertyInfo.SetValue(Obj, DateTime.Now, null);
                    propertyInfo = type.GetProperty("CreatedBy", BindingFlags.Instance | BindingFlags.Public, null, typeof(string), new Type[0], null);
                    propertyInfo.SetValue(Obj, /*user.UserID,*/ null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
