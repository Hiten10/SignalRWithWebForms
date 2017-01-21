using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SignalRWithWebForms.Repository;

namespace SignalRWithWebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod(UseHttpGet=true,ResponseFormat=ResponseFormat.Json)]
        public static IEnumerable<JobInfo> GetJobs()
        {
            var objRepo = new JobInfoRepository();
            return objRepo.GetData();
        }
    }
}