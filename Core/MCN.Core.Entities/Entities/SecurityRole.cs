using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityRole
    {
        public SecurityRole()
        {
            SecurityRoleAction = new HashSet<SecurityRoleAction>();
            SecurityRoleUser = new HashSet<SecurityRoleUser>();
        }

        public int SecurityRoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public int AdminOfficeId { get; set; }
        public bool IsOfficeAdmin { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
         
        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<SecurityRoleAction> SecurityRoleAction { get; set; }
        public virtual ICollection<SecurityRoleUser> SecurityRoleUser { get; set; }
    }
}
