using System;

namespace MCN.Common.AttribParam
{
    public class AttribConstants
    {
        public static class Messages
        {
            public static class Default
            {
                public static string List = "Return list";
                public static string ListNo = "Return no list";
                public static string Detail = "Return detail info";
                public static string DetailNo = "Return no detail info";
                public static string Save = "Detail will be saved";
                public static string SaveNo = "No detail will be saved";
                public static string Delete = "Info will be deleted sucessfully.";
                public static string DeleteNo = "No info will be deleted.";
                public static string ListSucess = "Sucess";
                public static string ListFailure = "Failure";
            }
            public static class Auth
            {
                public static string ValidateEmail = "Email Validated Successfully!";
                public static string NotValidateEmail = "This Username is not a valid.";
                public static string ValidatePassword = "Password Validated Successfully!";
                public static string NotValidatePassword = "This Password is not a valid.";
                public static string Exception = "Exception on validating the user.";
            }
        }
    }
}
