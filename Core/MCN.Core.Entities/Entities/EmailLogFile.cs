using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class EmailLogFile
    {
        public int EmailLogFileId { get; set; }
        public long EmailLogId { get; set; }
        public string AttachmentPath { get; set; }
        public string ContentType { get; set; }
        public string FileExtension { get; set; }

        public virtual EmailLog EmailLog { get; set; }
    }
}
