using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    public class ChangePasswordDTO
    {
        public string Password { get; set; }
        public string Token { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }

        public string formUrl { get; set; }
    }
}
