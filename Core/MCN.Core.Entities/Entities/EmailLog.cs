using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class EmailLog
    {
        public EmailLog()
        {
            EmailLogFile = new HashSet<EmailLogFile>();
            NlogEmailError = new HashSet<NlogEmailError>();
        }

        public long EmailLogId { get; set; }
        public string ToEmailName { get; set; }
        public string ToEmail { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        public string FromEmail { get; set; }
        public string FromEmailName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime? SentDate { get; set; }
        public int? Sent { get; set; }
        public int? SendCount { get; set; }
        public int? FailureCount { get; set; }
        public bool? ReadMessage { get; set; }
        public int? ReadCount { get; set; }
        public bool Archived { get; set; }
        public bool IsMobileMsg { get; set; }
        public string ToPhone { get; set; }
        public int? AdminOfficeId { get; set; }
        public int? FormId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
         
        public virtual User CreatedByNavigation { get; set; } 
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<EmailLogFile> EmailLogFile { get; set; }
        public virtual ICollection<NlogEmailError> NlogEmailError { get; set; }
    }
}
