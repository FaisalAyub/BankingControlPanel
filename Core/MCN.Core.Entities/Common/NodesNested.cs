using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Core.Entities.Common
{
    public class NodesNested
    {
        public NodesNested()
        {
            children = new List<NodesNested>();
        }
        public string title { get; set; }
        public string key { get; set; }
        public int id { get; set; }
        public bool expand { get; set; }
        public bool activate { get; set; }
        public bool select { get; set; }
        public List<NodesNested> children { get; set; }
    }
}
