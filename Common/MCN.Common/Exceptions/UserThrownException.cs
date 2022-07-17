using MCN.Common.AttribParam;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.Common.Exceptions
{
    public class UserThrownException : Exception
    {
        public SwallText swal { get; set; }
        
        public object Dataobj { get; set; }

        public UserThrownException(SwallText swall,object Data=null):base(swall.html)
        {
            this.Dataobj = Data;
            this.swal = swall;
            
        }
    }

    public class UserThrownBadRequest : Exception
    {
        public SwallText swal { get; set; }

        public object Dataobj { get; set; }

        public UserThrownBadRequest(SwallText swall, object Data=null) : base(swall.html)
        {
            this.Dataobj = Data;
            this.swal = swall;

        }
    }
}
