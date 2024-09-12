using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class JobInsertCls
    {
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