using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common
{
    public static class ServiceConfig
    {
        public static string ToLowerFirstChar(string value)
        {
            if (value == null) return "";
            if (String.IsNullOrWhiteSpace(value)) return value;
            char firstChar = Char.ToLowerInvariant(value[0]);
            if (value.Length == 1) return firstChar + "";
            return firstChar + value.Substring(1);
        }
    }
}
