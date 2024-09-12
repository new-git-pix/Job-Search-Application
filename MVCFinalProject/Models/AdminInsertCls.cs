using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class AdminInsertCls
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string name { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid Email ID")]
        public string email { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid Phone Number")]
        public string phone { get; set; }
        public string webaddress { get; set; }
        public string username { set; get; }
        public string password { set; get; }
        [Compare("password", ErrorMessage = "Password Mismatch")]
        public string cpassword { set; get; }
        public string adminmsg { get; set; }
    }
}