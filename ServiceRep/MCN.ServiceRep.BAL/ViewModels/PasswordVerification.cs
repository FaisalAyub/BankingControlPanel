using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels
{
   public class PasswordVerification
    {
        public string Url { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleType { get; set; }
    }
}
