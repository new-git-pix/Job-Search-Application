using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class UserRegController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: UserReg
        public ActionResult UserInsert_Pageload()
        {
            UserInsertCls user = new UserInsertCls();
            user.MyFavoriteQual = getQualificationData();
            return View(user);

        }
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                new CheckBoxListHelper{Value="BSC",Text="BSC",IsChecked=false},
                new CheckBoxListHelper{Value="MSC",Text="MSC",IsChecked=false},
                new CheckBoxListHelper{Value="BTECH",Text="BTECH",IsChecked=false},
                new CheckBoxListHelper{Value="MTECH",Text="MTECH",IsChecked=false},
            };
            return sts;
        }
        public ActionResult UserInsert_click(UserInsertCls ClsObj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/MVCFOL");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\MVCFOL", fname);
                    ClsObj.photo = fullpath;
                }
                var getuid = dbobj.sp_maxid().FirstOrDefault();
                int mid = Convert.ToInt32(getuid);
                int uid = 0;
                if (mid == 0)
                {
                    uid = 1;
                }
                else
                {
                    uid = mid + 1;
                }
                var quid = string.Join(",", ClsObj.SelectedQual);
                ClsObj.qual = quid;
                ClsObj.MyFavoriteQual = getQualificationData();
                dbobj.sp_userinsert(ClsObj.id, ClsObj.name, ClsObj.age, ClsObj.dob, ClsObj.gender, ClsObj.address, ClsObj.email, ClsObj.phone, ClsObj.photo, ClsObj.qual, ClsObj.mark, ClsObj.skill, ClsObj.experience);
                dbobj.sp_logininsert(ClsObj.id, ClsObj.username, ClsObj.password, "User");
                ClsObj.usermsg = "Inserted";
                return View("UserInsert_Pageload", ClsObj);
            }
            return View("UserInsert_Pageload", ClsObj);
        }
    }
}