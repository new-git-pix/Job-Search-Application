using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class JobUploadController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: JobUpload
        public ActionResult Job_UploadPage()
        {
            return View();
        }
        public ActionResult Job_InsertClick(JobInsertCls clsobj)
        {
           dbobj.sp_jobinsert(clsobj.cid, clsobj.title, clsobj.description, clsobj.type, clsobj.skills, clsobj.location, clsobj.salary, clsobj.vacancy, clsobj.experience, clsobj.lastdate, "Available");
            clsobj.jobmsg = "Inserted";
            return View("Job_UploadPage");
        }
    }
}