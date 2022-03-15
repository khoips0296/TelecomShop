using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Input Employee Name")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Input Password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}