using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class UsersAudit
    {
        public int UsersAuditId { get; set; }
        public int UserId { get; set; }
        public DateTime? AccessDateTime { get; set; }
        public Guid? Guid { get; set; }

        public virtual User User { get; set; }
    }
}
