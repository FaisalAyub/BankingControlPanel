using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    /// <summary>
    /// PasswordChangeDto chnage password by using old password
    /// </summary>
    public class PasswordChangeDto
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// OldPassword
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
