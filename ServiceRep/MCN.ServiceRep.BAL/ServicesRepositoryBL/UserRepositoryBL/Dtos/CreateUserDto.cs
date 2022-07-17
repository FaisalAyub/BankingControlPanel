using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos
{
 public   class CreateUserDto
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; } 
        public string BaseURL { get; set; }
        public string IpAddress { get; set; }
        public Double Latitude { get; set; } 
        public Double Longitude { get; set; }
    }
}
