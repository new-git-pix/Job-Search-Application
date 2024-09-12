using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class JobSearchCls
    {
        public JobSearchCls()
        {
            selectjob = new List<SelectAllJobsCls>();
            insertjob = new SelectAllJobsCls();
        }
        public SelectAllJobsCls insertjob { set; get; }
        public List<SelectAllJobsCls> selectjob { set; get; }
    }
    public class SelectAllJobsCls
    {
        public int jid { get; set; }
        public int cid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string skills { get; set; }
        public string location { get; set; }
        public string salary { get; set; }
        public string vacancy { get; set; }
        public string experience { get; set; }
        public string lastdate { get; set; }
        public string status { get; set; }
        public string jobmsg { get; set; }
    }
}