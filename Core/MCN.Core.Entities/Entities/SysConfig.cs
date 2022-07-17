using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SysConfig
    {
        public int SysConfigId { get; set; }
        public string SuperAdminUserLoginTypeKey { get; set; }
        public string AdminOfficeUserLoginTypeKey { get; set; }
        public string FormUserUserLoginTypeKey { get; set; }
        public string RecomenderUserLoginTypeKey { get; set; }
        public bool UserAuditLog { get; set; }
        public int TokenExpiryHours { get; set; }
        public bool EnabledMultiFactor { get; set; }
        public string PageTypeKeyApplicant { get; set; }
        public string PageTypeKeyRecommender { get; set; }
        public string PageTypeKeyReviewer { get; set; }
        public string PageTypeKeyEndorser { get; set; }
    }
}
