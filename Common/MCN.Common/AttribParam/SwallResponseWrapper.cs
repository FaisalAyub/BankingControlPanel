using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common.AttribParam
{
    public class SwallResponseWrapper
    {
        public SwallText SwallText { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

    }
}
