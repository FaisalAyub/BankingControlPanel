using MCN.Core.Entities.Entities; 

namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    public class PasscodeEmailDTO
    {
        public string PassCode { get; set; }
        public User User { get; set; } 
    }
}
