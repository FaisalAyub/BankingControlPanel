using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    public class EmailVerificationDTO
    {
        public string Passcode { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }
    }
}
