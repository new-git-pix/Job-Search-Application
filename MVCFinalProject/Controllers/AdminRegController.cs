using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class AdminRegController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: AdminReg
        public ActionResult AdminInsert_Pageload()
        {
            return View();
        }
        public ActionResult AdminInsert_Click(AdminInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
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
                dbobj.sp_admininsert(clsobj.id, clsobj.name, clsobj.email, clsobj.phone, clsobj.webaddress);
                dbobj.sp_logininsert(clsobj.id, clsobj.username, clsobj.password, "Admin");
                clsobj.adminmsg = "Inserted";
                return View("AdminInsert_Pageload", clsobj);
            }
            return View("AdminInsert_Pageload", clsobj);
        }
    }
}