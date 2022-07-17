using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class NlogEmailError
    {
        public long NlogEmailErrorId { get; set; }
        public long? EmailLogId { get; set; }
        public DateTime DtLogdate { get; set; }
        public string SMessage { get; set; }

        public virtual EmailLog EmailLog { get; set; }
    }
}
