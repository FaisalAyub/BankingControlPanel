using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class Smtpsettings
    {
        public int SmtpsettingsId { get; set; }
        public int? AdminOfficeId { get; set; }
        public int? FormId { get; set; }
        public string Smtpserver { get; set; }
        public string Smtpuser { get; set; }
        public string Smtppassword { get; set; }
        public string Smtpport { get; set; }
        public bool EnabledSsl { get; set; }
        public bool EmailHtmlbody { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual User CreatedBy1 { get; set; } 
        public virtual User UpdatedByNavigation { get; set; }
    }
}
