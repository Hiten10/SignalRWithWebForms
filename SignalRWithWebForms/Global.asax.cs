using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SignalRWithWebForms;

namespace SignalRWithWebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );

            SqlDependency.Start(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString); 
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString); 
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
