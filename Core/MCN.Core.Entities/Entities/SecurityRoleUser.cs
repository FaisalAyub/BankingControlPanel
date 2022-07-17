using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityRoleUser
    {
        public int SecurityRoleUserId { get; set; }
        public int SecurityRoleId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual SecurityRole SecurityRole { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
