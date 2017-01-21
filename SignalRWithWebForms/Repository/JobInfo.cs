using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRWithWebForms.Repository
{
    public class JobInfo
    {
        public int JobID { get; set; }
        public string Name { get; set; }
        public DateTime LastExecutionDate { get; set; }
        public string Status { get; set; }
    }
}