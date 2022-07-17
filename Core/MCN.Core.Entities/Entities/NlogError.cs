using System;
using System.Collections.Generic;

namespace MCN.Core.Entities.Entities
{
    public partial class NlogError
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string CallSite { get; set; }
        public string Thread { get; set; }
        public string Exception { get; set; }
        public string Stacktrace { get; set; }
        public string Port { get; set; }
        public string Url { get; set; }
        public string Https { get; set; }
        public string ServerAddress { get; set; }
        public string RemoteAddress { get; set; }
    }
}
