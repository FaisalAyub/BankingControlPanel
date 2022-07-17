using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Core.Entities.Common
{
    public class ResponseText<T> where T:class
    {        
        public T swallText { get; set; }
        public string jsonResult { get; set; }
    }
}
