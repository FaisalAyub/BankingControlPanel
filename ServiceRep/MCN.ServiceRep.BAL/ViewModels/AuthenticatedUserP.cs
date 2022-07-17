
using MCN.Core.Entities.Common;

namespace MCN.ServiceRep.BAL.ViewModels
{
    public class AuthenticatedUserP
    { 
        public AuthUserP authUser { get; set; }
        public AuthUserP clientUser { get; set; }
        public AuthUserP adminUser { get; set; }
        public AuthUserP formUser { get; set; }  
        public bool NoAuidtLog { get; set; }
    }
}
