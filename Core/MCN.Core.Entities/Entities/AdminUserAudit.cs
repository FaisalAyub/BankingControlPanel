using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class AdminUserAudit
    {
        public int AdminUserAuditId { get; set; }
        public int AdminUserId { get; set; }
        public DateTime? AccessDateTime { get; set; }
        public Guid? Guid { get; set; }
         
    }
}
