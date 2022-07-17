using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    public class CreateUserDTO
    {
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string formUrl { get; set; }
        public string BaseURL { get; set; }
        public string IpAddress { get; set; }
    }
}
