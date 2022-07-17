using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCN.Core.Entities.Entities
{
    public class UserAuthtoken
    {
        [Key]
        public int ID { get; set; }
        public string Authtoken { get; set; }
        public string AccessIP { get; set; }
        public int? UserID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual User User { get; set; } 
    }
}
