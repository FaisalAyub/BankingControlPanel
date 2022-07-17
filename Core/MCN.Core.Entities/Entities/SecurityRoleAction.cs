using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityRoleAction
    {
        public int SecurityRoleActionId { get; set; }
        public int? SecurityEntityTypeId { get; set; }
        public int? EntityId { get; set; }
        public int? SecurityRoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual SecurityEntityType SecurityEntityType { get; set; }
        public virtual SecurityRole SecurityRole { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
    }
}
