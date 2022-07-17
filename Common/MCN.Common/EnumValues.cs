using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCN.Common
{
    public class EnumValues:StringEnum 
    {
        public EnumValues(Enum value) :base(value)
        {

        }
        public enum EUserAuditTypes
        {
            [Description("USAT-0000001")]
            ValidateRequest=1,
            [Description("USAT-0000002")]
            AdminOffice=2,
            [Description("USAT-0000003")]
            Application=3
        }       
    }
}
