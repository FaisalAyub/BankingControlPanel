using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common.AttribParam
{
    
    public static class SwalType
    {
        public readonly static string Success = "success";
        public readonly static string Error = "error";
        
    }

    public static  class LoginSwallMessagesHtml
    {

        public static SwallText UserAlreadyExist=new SwallText("error","Invalid Operation","User already exists with the same email.");


        public static string ForgotPasswordEmailHtmlSuccess(string Email)
        {
            return $"An email has sent to your email: \"{Email}\"." +
                $"Please check your email and follow the instructions.";
        }
        public readonly static string ForgotPasswordEmailTitleSuccess = "Password Reset Email Sent!";

        public readonly static string 
            ResetPasswordTokenExpireHtmlFailure = "The link has expired. Please request againg to reset password.";
       public readonly
            static string 
            ResetPasswordTokenExpireTitleFailure = "The link has expired.";
        public readonly static string
             ResetPasswordInvUserHtmlFailure = "Invalid user is trying to reset the password.";
        public readonly
             static string
             ResetPasswordInvUserTitleFailure = "Email verification failed.";
        public readonly static string
             ResetPasswordChangedHtmlSuccess= "Password has been changed successfuly. Please login with new password.";
        public readonly
             static string
             ResetPasswordChangedTitleFailure = "Password changed successfuly.";
        public readonly
           static string
           OldPasswordNotCorrect = "Old Password is not correct";
        public readonly
          static string
          ChangePasswordFail = "Change Password Fail";
        public readonly
         static string
            UnAuthorizedUser = "User is not authorized";
        public readonly
        static string
           UnAuthorized = "UnAuthorize";
    }
   
        public class SwallTextData
    {

        

        public class LoginUser
        {
            public static SwallText UserCreatedScuccessfully = new SwallText("success", "User has been created successfuly", "");

            public static SwallText EmailVerifcationInvalidUser = new SwallText("error", "Invalid User", "No user exist to generate email verification email");

            public SwallText SwallTextLoginError = new SwallText("error", "Login Failed!", "Wrong username/password");
            public SwallText SwallTextLoginErrorBlocked = new SwallText("error", "Login Failed!", "You have been blocked for too many failed attempts. Please Contact your system administrator.");
            public SwallText SwallTextLoginSuccess = new SwallText("success", "Login Successfull!", "You have been logedin Successfully.");
            public SwallText SwallTextLoginTokenSent = new SwallText("warning", "Login Token Sent!", "Your passcode has been sent Successfully.");
            public SwallText SwallTextLoginInvalidToken = new SwallText("warning", "Invalid Token!", "Your passcode is not valid.");
            public SwallText SwallTextLoginTokenSucess = new SwallText("success", "Login Token Sucess!", "Your passcode has been verified Successfully.");
            public SwallText SwallTextEmailVerifiedSuccess = new SwallText("success", "Email Verification Success!", "Your email has been verified Successfully.");
            public SwallText SwallTextEmailVerifiedFailure = new SwallText("error", "Email Verification Failed!", "Your email cannot be verified successfully.Please enter a valid email.");
            public SwallText SwallTextPasswordVerifiedSuccess= new SwallText("success", "Password Verification Success!", "Your password has been verified Successfully.");
            public SwallText SwallTextEmailPasswordFailure = new SwallText("error", "Password Verification Failed!", "Your password cannot be verified successfully.Please enter a valid password.");
            public SwallText SwallTextEmailPasscodeVerifiedSuccess = new SwallText("success", "Email Passcode Verification Success!", "Your Email Passcode has been verified Successfully.");
            public SwallText SwallTextEmailPasscodeFailure = new SwallText("error", "Email Passcode Verification Failed!", "Your Email Passcode cannot be verified successfully.Please enter a valid Email Passcode.");
            public SwallText SwallTextUrlNoExist = new SwallText("error", "Form Url Not Valid", "Your Form URL is Not Valid");

        }
        public class Registration
        {
            public SwallText SwallTextRegistrationControllerError = new SwallText("error", "Problem in Saving!", "Please contact Administrator");
            public SwallText SwallTextRegistrationControllerErrorEmailExists = new SwallText("error", "Email Exists!", "Email already registered with this Email in our system. Try to add another Email");
            public SwallText SwallTextRegistrationControllerErrorUserNameExists = new SwallText("error", "User Name!", "User Name already registered with this User Name in our system. Try to add User Name with another User Name.");
            public SwallText SwallTextRegistrationControllerSuccess = new SwallText("success", "Saved Successfully!", "");
            public SwallText SwallTextRegistrationAdminOfficeCreatedSuccessfully = new SwallText("success", "Successfull", "Admin Office Created swuccessfully");
        }
        public class Common
        {
            public static SwallText SaveSuccess = new SwallText("success", "Saved Successfully!", "");
            public static SwallText NotSaveSuccess = new SwallText("error", "Not Save Successfully!", "");
            public static SwallText Delete = new SwallText("success", "Deleted Successfully!", "");
            public static SwallText NotDelete = new SwallText("error", "Not Deleted Successfully!", "");
            public static SwallText Detail = new SwallText("success", "fetch details!", "");
            public static SwallText NotDetail = new SwallText("error", "No detail fetch!", "");
            public static SwallText List = new SwallText("success", "fetch List!", "");
            public static SwallText NotList = new SwallText("error", "No list fetch!", "");
            public static SwallText Exception = new SwallText("error", "Exception!", "");
        }
        public static class Auth
        {
            public static SwallText ValidateEmail = new SwallText("success", "Email Validated Successfully!", "");
            public static SwallText NotValidateEmail = new SwallText("error", "This Username is not a valid.", "");
            public static SwallText ValidatePassword = new SwallText("success", "Password Validated Successfully!", "");
            public static SwallText NotValidatePassword = new SwallText("error", "This Password is not a valid.", "");
            public static SwallText Exception = new SwallText("error", "Exception!", "");
        }

        public class FormMessages
        {
            public static SwallText formNotFound = new SwallText("error",  "Not Found", "The requested form can not be found.");
            public static SwallText formNotValid = new SwallText("error", "Not Valid", "Form is not valid");

        }

    }
}
