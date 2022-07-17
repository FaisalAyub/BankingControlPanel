using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityEntityType
    {
        public SecurityEntityType()
        {
            SecurityRoleAction = new HashSet<SecurityRoleAction>();
        }

        public int SecurityEntityTypeId { get; set; }
        public string EntityTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<SecurityRoleAction> SecurityRoleAction { get; set; }
    }
}
