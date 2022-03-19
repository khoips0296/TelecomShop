using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email can not be emptied!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Password can not be emptied!")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}