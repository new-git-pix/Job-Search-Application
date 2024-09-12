using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFinalProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCFinalProject.Controllers
{
    public class DisplayAllJobsController : Controller
    {
        JobPortalDBEntities dbobj = new JobPortalDBEntities();
        // GET: DisplayAllJobs
        public ActionResult AllJobs_Pageload()
        {
            return View(GetData());
        }
        private JobSearchCls GetData()
        {
            var joblist = new JobSearchCls();
            List<string> lst = new List<string>();
            var job = dbobj.JobTables.ToList();
            foreach (var e in job)
            {
                var jobcls = new SelectAllJobsCls();
                jobcls.jid = e.Job_Id;
                jobcls.cid = e.Company_Id;
                jobcls.title = e.Job_Title;
                jobcls.description = e.Job_Description;
                jobcls.type = e.Job_Type;
                jobcls.location = e.Job_Location;
                jobcls.skills = e.Job_Skills;
                jobcls.salary = e.Job_Salary;
                jobcls.vacancy = e.Job_Vacancies;
                jobcls.experience = e.Job_Experience;
                jobcls.lastdate = e.Last_Date;
                jobcls.status = e.Job_Status;

                joblist.selectjob.Add(jobcls);
                var s = jobcls.skills;
                lst.Add(s);
                TempData["skl"] = string.Join(" ", lst);
            }
            return joblist;
        }
        public ActionResult SearchJob_Click(JobSearchCls clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertjob.experience))
            {
                qry += " and Job_Experience like '%" + clsobj.insertjob.experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertjob.skills))
            {
                qry += " and Job_Skills like '%" + clsobj.insertjob.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertjob.location))
            {
                qry += " and Job_Location like '%" + clsobj.insertjob.location + "%'";
            }
            return View("AllJobs_Pageload", getdata1(clsobj, qry));
        }
        private JobSearchCls getdata1(JobSearchCls clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearchCls();
                while (dr.Read())
                {
                    var jobcls = new SelectAllJobsCls();
                    jobcls.jid = Convert.ToInt32(dr["Job_Id"].ToString());
                    jobcls.cid = Convert.ToInt32(dr["Company_Id"].ToString());
                    jobcls.title = dr["Job_Title"].ToString();
                    jobcls.description = dr["Job_Description"].ToString();
                    jobcls.type = dr["Job_Type"].ToString();
                    jobcls.location = dr["Job_Location"].ToString();
                    jobcls.skills = dr["Job_Skills"].ToString();
                    jobcls.salary = dr["Job_Salary"].ToString();
                    jobcls.vacancy = dr["Job_Vacancies"].ToString();
                    jobcls.experience = dr["Job_Experience"].ToString();
                    jobcls.lastdate = dr["Last_Date"].ToString();
                    jobcls.status = dr["Job_Status"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }
    }
}