using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Core.Entities.Base
{
    public class BaseEntity
    {
        public string CreatedBy  { get;set;}
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }       
        public DateTime? UpdatedOn { get; set; }
    }
}
