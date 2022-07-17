using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MCN.Common
{
    public class StringEnum
    {
        public string outputDes = null;
        public StringEnum(Enum value) {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null &&
                    attributes.Length > 0)
                {
                    outputDes = attributes[0].Description;
                }
                outputDes = "";
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
