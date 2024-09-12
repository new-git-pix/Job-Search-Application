using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class LoginCls
    {
        public int userid { get; set; }
        [Required(ErrorMessage = "***")]
        public string username { get; set; }
        [Required(ErrorMessage = "***")]
        public string password { get; set; }
        public string msg { get; set; }
        public string logtype { get; set; }
    }
}