using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class ApplyJobController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: ApplyJob
        public ActionResult ApplyJob_Pageload()
        {
            return View();
        }
        public ActionResult Apply_InsertClick(ApplyJobCls clsobj, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                var s = Server.MapPath("~/MVCFOL");
                string pa = Path.Combine(s, fname);
                file.SaveAs(pa);

                var fullpath = Path.Combine("~\\MVCFOL", fname);
                clsobj.resume = fullpath;
            }
            dbobj.sp_applyjob(clsobj.ajobid, clsobj.uid, clsobj.cid, clsobj.resume, clsobj.adt, "Applied");
            clsobj.amsg = "Inserted";
            return View("ApplyJob_Pageload");
        }
    }
}