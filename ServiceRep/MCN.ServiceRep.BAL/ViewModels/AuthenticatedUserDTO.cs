using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels
{
    public class AuthenticatedUserDTO
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool? IsActive { get; set; }
        public int LoginFailureCount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UserLoginTypeId { get; set; }
    }
}
