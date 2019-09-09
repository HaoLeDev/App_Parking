using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Parking.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Nhập user name")]
        public string UserName { set; get; }
       // [Required(ErrorMessage = "Nhập password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}