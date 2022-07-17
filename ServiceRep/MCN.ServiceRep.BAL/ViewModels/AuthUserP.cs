
using MCN.Core.Entities.Entities;

namespace MCN.ServiceRep.BAL.ViewModels
{
    public class AuthUserP
    {
        public User user { get; set; }
        public bool InValidUser { get; set; }
        public bool IsUser { get; set; }
        public bool IsActive { get; set; }
        public bool IsUserAudit { get; set; }
        public bool IsBlocked { get; set; }
        public bool ValidateToken { get; set; }
        public bool ResendToken { get; set; }
        public bool VerifiedUser { get; set; }
        public string verifyUser { get; set; }
        public string AdminOfficeKey { get; set; }
        public string Authtoken { get; set; }
        public string MobileToken { get; set; }
        public string EmailToken { get; set; }
        public bool EnabledMultiFactor { get; set; }
        public bool SendToken { get; set; }
        public bool IsVerifyMultiToken { get; set; }
    }
}
