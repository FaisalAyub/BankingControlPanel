using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MCN.Common.AttribParam;
using MCN.Core.Entities.Entities;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos;
using MCN.ServiceRep.BAL.ViewModels;
using MCN.ServiceRep.BAL.ViewModels.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static MCN.Common.AttribParam.SwallTextData;

namespace MCN.WebAPI.Areas.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepositoryBL _UserRepositoryBL;
        private IHttpContextAccessor _accessor; 
        private string _IpAddress;
        private string _baseuri;
        private IConfiguration _config;

        public UsersController(IUserRepositoryBL UserRepositoryBL, IHttpContextAccessor accessor, IConfiguration config)
        {
            _UserRepositoryBL = UserRepositoryBL;
            _accessor = accessor;
            _config = config;
            _IpAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(); 
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateEmail")]
        public IActionResult ValidateEmail([FromQuery]string Email, string Url, string RoleType)
        {

            var result = _UserRepositoryBL.IsValidUserEmail(Email, Url, RoleType);


            return Ok(result);
        }

    
        [HttpGet]
        [AllowAnonymous]
        [Route("VerifyEmailPasscode")]
        public IActionResult ValidateEmailPasscode(string emailPasscode, string email)
        {
            
                var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                IActionResult response = Unauthorized();
                var result = _UserRepositoryBL.IsValidEmailPasscode(emailPasscode, ip, email);
            if (result == null)
            {
                return Ok(new SwallResponseWrapper { Data = null, StatusCode = 401, SwallText = new LoginUser().SwallTextEmailPasscodeFailure });
            }
                var tokenString = GenerateJSONWebToken((User)result.Data);
                //return Ok(new UserResult { token = tokenString, User = (User)result.Data,message=result. });
                return Ok(new SwallResponseWrapper { Data = new UserResult { token = tokenString, User = (User)result.Data }, StatusCode = result.StatusCode, SwallText = result.SwallText });
            
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ValidateEmailPassword")]
        public IActionResult ValidateEmailPassword(string password, string email)
        {

            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            IActionResult response = Unauthorized();
            var result = _UserRepositoryBL.IsValidPassword(password,email,ip);
            if (result.Data == null)
            {
                return Ok(new SwallResponseWrapper { Data = null, StatusCode = 401, SwallText = new LoginUser().SwallTextEmailPasswordFailure });
            }
            var tokenString = GenerateJSONWebToken((User)result.Data);
            //return Ok(new UserResult { token = tokenString, User = (User)result.Data,message=result. });
            return Ok(new SwallResponseWrapper { Data = new UserResult { token = tokenString, User = (User)result.Data }, StatusCode = result.StatusCode, SwallText = result.SwallText });

        }


        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, userInfo.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, userInfo.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      
 

        [HttpPost]
        [Route("CreateUser")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody]CreateUserDto dto)
        {
            dto.IpAddress = _IpAddress;
            dto.BaseURL = _baseuri;
            var result = _UserRepositoryBL.CreateUser(dto);
            return Ok(result);
        }

        [HttpPost]
        [Route("ReGenerateEmailVerificationMail")]
        [AllowAnonymous]
        public IActionResult ReGenerateEmailVerificationPasscode(CreateUserDto createUserDto)
        {
          var response=  _UserRepositoryBL.ReGenerateEmailVerificationPasscode(createUserDto, _IpAddress);
            return Ok(response);
        }

        [HttpPost]
        [Route("EmailVerification")]
        [AllowAnonymous]
        public IActionResult EmailVerification([FromBody]EmailVerificationDTO dto)
        {
            var result = _UserRepositoryBL.IsEmailVerified(dto.Passcode, _IpAddress, dto.Email);
            return Ok(result);
        }

        //[HttpPost]
        //[Route("PasswordChange")]
        //[Authorize]
        //public IActionResult PasswordChange([FromBody]PasswordChangeDto passwordChangeDto)
        //{
        //    //var user = _accessor.HttpContext.User.Claims.Select(x => x.Value).FirstOrDefault();
        //    var email = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
        //    passwordChangeDto.Email = email;
        //    var result = _UserRepositoryBL.PasswordChange(passwordChangeDto);
        //    return Ok(result);
        //}

        [Authorize]
        [HttpGet]
        [Route("TestToken")]
        public IActionResult TestToken()
        {
            //var user= _accessor.HttpContext.User.Claims.Select(x=>x.Value).FirstOrDefault();
            return Ok(new { tok = "token was here" });
        }


    }
}
