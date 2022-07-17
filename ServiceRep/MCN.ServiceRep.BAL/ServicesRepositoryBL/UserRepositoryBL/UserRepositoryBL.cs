using MCN.Common;
using MCN.Common.AttribParam;
using MCN.Common.Exceptions;
using MCN.Core.Entities.Entities;
using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos;
using MCN.ServiceRep.BAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using static MCN.Common.AttribParam.SwallTextData;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL
{
    public class UserRepositoryBL : BaseRepository, IUserRepositoryBL
    { 
        private readonly SwallResponseWrapper _swallResponseWrapper;
        private readonly SwallText _swallText; 
        public static int DEFAULT_USERID = 1;

        public UserRepositoryBL(RepositoryContext repository) : base(repository)
        {
            _swallResponseWrapper = new SwallResponseWrapper();
            _swallText = new SwallText(); 
            repositoryContext = repository; 
        }


        public SwallResponseWrapper IsValidUserEmail(string email, string Url, string RoleType)
        {
            var usr = new User();

            var IsValidEmail = repositoryContext.Users.FirstOrDefault(x => x.Email == email);
            if (IsValidEmail != null && IsValidEmail.IsEmailVerified==true)
            {
                return new SwallResponseWrapper()
                {
                    SwallText = new LoginUser().SwallTextEmailVerifiedSuccess,
                    StatusCode = 200,
                    Data = null
                };
            }
            else  if(IsValidEmail != null && IsValidEmail.IsEmailVerified == false)
            {
                return new SwallResponseWrapper()
                {
                    SwallText =new LoginUser().SwallTextEmailVerifiedFailure,
                    StatusCode = 401,
                    Data = usr
                };
            }
            else
            {
                return new SwallResponseWrapper()
                {
                    SwallText = LoginUser.EmailVerifcationInvalidUser,
                    StatusCode = 404,
                    Data = usr
                };
            }
        }



        public SwallResponseWrapper ReGenerateEmailVerificationPasscode(CreateUserDto userDto, string IpAddress)
        {
            var context = repositoryContext;

            var usr = context.Users.AsNoTracking().FirstOrDefault(x => x.Email == userDto.Email);
            if (usr == null)
            {
                CreateUserDto createUserDto = new CreateUserDto() { Email = userDto.Email };
                var response = CreateUser(createUserDto);
                if (response.StatusCode == 200)
                {
                    return new SwallResponseWrapper()
                    {
                        SwallText = LoginUser.EmailVerifcationInvalidUser,
                        StatusCode = 1,
                        Data = null
                    };

                }

            }
            else if (usr.Email != null && usr.Password == null)
            {
                var passcode = RandomHelper.GetRandomNumber().ToString("x");
                SavePasscode(passcode, IpAddress, usr.ID);
                return new SwallResponseWrapper()
                {
                    SwallText = LoginUser.EmailVerifcationInvalidUser,
                    StatusCode = 1,
                    Data = usr
                };
            }
            else if (usr.Email != null && usr.Password != null)
            {

                return new SwallResponseWrapper()
                {
                    SwallText = null,
                    StatusCode = 2,
                    Data = usr
                };

            }

 
            return new SwallResponseWrapper()
            {
                SwallText = null,
                StatusCode = 0,
                Data = null
            };
        }

        public SwallResponseWrapper CreateUser(CreateUserDto dto)
        {
            User usr = new User
            {
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                CreatedBy = DEFAULT_USERID,
                Email = dto.Email,
                FirstName = dto.FirstName,
                IsActive = true,
                LastName = dto.LastName,
                LoginFailureCount = 0,
                Password = dto.Password,
                UpdatedBy = DEFAULT_USERID,
                IsEmailVerified = false,
                UserLoginTypeId = AppConstants.UserEntityType.Applicant,//edit here  
            }; 

            repositoryContext.Users.Add(usr);
            repositoryContext.SaveChanges();
            var passcode = RandomHelper.GetRandomNumber().ToString("x");
            SavePasscode(passcode, dto.IpAddress, usr.ID);
 
            return new SwallResponseWrapper()
            {
                SwallText = LoginUser.UserCreatedScuccessfully,
                StatusCode = 200,
                Data = usr
            };
        }
         

        public SwallResponseWrapper IsEmailVerified(string Passcode, string IpAddress, string Email)
        {
            var result = checkPasscode(Passcode, IpAddress, Email);

            if (result != null)
            {
                var user = repositoryContext.Users.FirstOrDefault(x => x.Email == Email);
                user.IsEmailVerified = true;
                repositoryContext.Entry(user).State = EntityState.Modified;
                repositoryContext.SaveChanges();

                return new SwallResponseWrapper()
                {
                    StatusCode = 200,
                    SwallText = new LoginUser().SwallTextEmailPasscodeVerifiedSuccess
                    ,
                    Data = repositoryContext.Users
                    .Where(x => x.ID == result.UserID).FirstOrDefault()
                };
            }
            else
                return null;
        }

        public SwallResponseWrapper IsValidEmailPasscode(string Passcode, string IpAddress, string Email)
        {
            var result = checkPasscode(Passcode, IpAddress, Email);

            return result != null ?
                new SwallResponseWrapper()
                {
                    StatusCode = 200,
                    SwallText = new LoginUser().SwallTextEmailPasscodeVerifiedSuccess,
                    Data = repositoryContext.Users
                    .Where(x => x.ID == result.UserID).FirstOrDefault()
                }
                :
                 null;
        }

        public UserMultiFactor checkPasscode(string Passcode, string IpAddress, string Email)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.Email == Email);

            if (user != null)
            {
                var passcodeSuccess = repositoryContext.UserMultiFactors.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => x.AccessIP == IpAddress && x.UserID == user.ID);

                if (passcodeSuccess?.EmailToken == Passcode)
                {
                    user.IsEmailVerified = true;
                    repositoryContext.Entry(user).State = EntityState.Modified;
                    repositoryContext.SaveChanges();

                    return passcodeSuccess;
                }
                else
                {
                    //throw new UserThrownBadRequest(new LoginUser().SwallTextEmailPasscodeFailure, null);
                    return null;
                }

            }
            else
            {
                // throw new UserThrownBadRequest(new LoginUser().SwallTextEmailPasscodeFailure, null);
                return null;
            }
        }

        public SwallResponseWrapper IsValidPassword(string Password,
            string Email, string IpAddress)
        {
            // var user = GetUserByUrlEmail(Email, Url);

            var user = (from u in repositoryContext.Users
                        where u.Email.ToLower() == Email.ToLower() && u.Password == Password && u.IsEmailVerified==true
                        select u).FirstOrDefault();

            if (user == null)
            {
                return new SwallResponseWrapper()
                {
                    Data = null,
                    StatusCode = 404,
                    SwallText = new LoginUser().SwallTextEmailVerifiedFailure
                };

            }
            return new SwallResponseWrapper()
            {
                Data = user,
                StatusCode = 200,
                SwallText = new LoginUser().SwallTextPasswordVerifiedSuccess
            };
        }


        private void SavePasscode(string Passcode, string IpAddress, int userId)
        {

            var obj = new UserMultiFactor();
            obj.AccessIP = IpAddress;
            obj.CreatedOn = DateTime.Now;
            obj.EmailToken = Passcode;
            obj.UpdatedOn = DateTime.Now;
            obj.UserID = userId;      
            repositoryContext.UserMultiFactors.Add(obj);
            repositoryContext.SaveChanges();
        }

        

        public User GetUser(int userID)
        {
            var user = repositoryContext.Users.FirstOrDefault(x => x.ID == userID && x.UserLoginTypeId == AppConstants.UserEntityType.Applicant);

            return user;
        }




    }
}
