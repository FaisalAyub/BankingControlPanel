using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityCategory
    {
        public SecurityCategory()
        {
            InverseParentSecurityCategory = new HashSet<SecurityCategory>();
            SecurityAction = new HashSet<SecurityAction>();
        }

        public int SecurityCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? ParentSecurityCategoryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual SecurityCategory ParentSecurityCategory { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<SecurityCategory> InverseParentSecurityCategory { get; set; }
        public virtual ICollection<SecurityAction> SecurityAction { get; set; }
    }
}
