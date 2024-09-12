using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class CheckBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }

    }
    public class UserInsertCls
    {
        public List<CheckBoxListHelper> MyFavoriteQual { get; set; }
        public string[] SelectedQual { get; set; }
        public int id { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string name { get; set; }
        [Range(21, 35, ErrorMessage = "Enter the age")]
        public int age { get; set; }
        public string dob { get; set; }
        [Required(ErrorMessage = "Enter the Gender")]
        public string gender { get; set; }
        public string address { get; set; }
        [EmailAddress(ErrorMessage = "Enter valid Email ID")]
        public string email { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid Phone Number")]
        public string phone { get; set; }
        public string photo { get; set; }
        public string qual { get; set; }
        public string mark { get; set; }
        public string skill { get; set; }
        public string experience { get; set; }
        public string username { set; get; }
        public string password { set; get; }
        [Compare("password", ErrorMessage = "Password Mismatch")]
        public string cpassword { set; get; }
        public string usermsg { get; set; }
    }
}