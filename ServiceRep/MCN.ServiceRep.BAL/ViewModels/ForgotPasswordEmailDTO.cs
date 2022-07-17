using MCN.Core.Entities.Entities; 

namespace MCN.ServiceRep.BAL.ViewModels
{
    public class ForgotPasswordEmailDTO
    {
        public string token { get; set; }
        public User User { get; set; } 
        public string BaseUrl { get; set; }
    }
}
