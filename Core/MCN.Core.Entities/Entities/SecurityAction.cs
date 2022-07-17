using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class SecurityAction
    {
        public int SecurityActionId { get; set; }
        public string ActionName { get; set; }
        public bool IsActive { get; set; }
        public int SecurityCategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual SecurityCategory SecurityCategory { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
    }
}
