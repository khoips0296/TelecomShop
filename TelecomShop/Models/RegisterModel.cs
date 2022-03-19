using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelecomShop.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email can not be emptied!")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Password can not be emptied!")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required(ErrorMessage = "Confirm Password can not be emptied!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match!")]
        public string ConfirmPassword { set; get; }
        [Required(ErrorMessage = "Name can not be emptied!")]
        public string FullName { set; get; }
        [Required(ErrorMessage = "Phone can not be emptied!")]
        public string Phone { set; get; }
        public bool Gender { set; get; }
    }
}