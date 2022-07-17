using MCN.Common.AttribParam;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL
{
    public interface IUserRepositoryBL
    {
        SwallResponseWrapper IsValidUserEmail(string email, string Url, string RoleType);
        SwallResponseWrapper IsValidPassword(string Password, string Email, string IpAddress);
        //SwallResponseWrapper IsValidAdminPassword(string Password, string Email);
        SwallResponseWrapper IsValidEmailPasscode(string Passcode, string IpAddress, string Email); 
        //SwallResponseWrapper ResetPassword(ChangePasswordDTO resetPassword);
        SwallResponseWrapper IsEmailVerified(string Passcode, string IpAddress, string Email);
        SwallResponseWrapper CreateUser(CreateUserDto dto);
        //SwallResponseWrapper PasswordChange(PasswordChangeDto passwordChangeDto);
        SwallResponseWrapper ReGenerateEmailVerificationPasscode(CreateUserDto userDto, string IpAddress);
       // Result<UserDto> Users(UserCriteria criteria);
        //User GetUser(int userID); 
    }
}
