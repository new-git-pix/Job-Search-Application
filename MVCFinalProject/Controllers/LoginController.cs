using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class LoginController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: Login
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(LoginCls clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(clsobj.username, clsobj.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(clsobj.username, clsobj.password).FirstOrDefault();
                    Session["uid"] = uid;
                    var lgtp = dbobj.sp_logtype(clsobj.username, clsobj.password).FirstOrDefault();
                    if (lgtp == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lgtp == "Admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "Invalid Login";
                return View("Login_PageLoad", clsobj);
            }
            return View("Login_PageLoad", clsobj);
        }
    }
}