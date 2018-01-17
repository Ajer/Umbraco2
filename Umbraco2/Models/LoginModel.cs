using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Umbraco2.Models
{
        public class LoginModel
        {
            [DisplayName("Username")]
            public string Username { get; set; }

            [DisplayName("Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DisplayName("Remember Me")]
            public bool RememberMe { get; set; }
        }

}