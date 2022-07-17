using MCN.Core.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL.Dtos
{
  public  class UserResult
    {
        public User User { get; set; }
        public string token { get; set; }
    }
}
