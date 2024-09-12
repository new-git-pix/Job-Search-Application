using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class ApplyJobCls
    {
        public int ajobid { set; get; }
        public int uid { set; get; }
        public int cid { set; get; }
        public string resume { set; get; }
        public string adt { set; get; }
        public string stat { set; get; }
        public string amsg { set; get; }
    }
}