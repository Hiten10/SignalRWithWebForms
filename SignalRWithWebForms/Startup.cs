using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

namespace SignalRWithWebForms
{
    [assembly: OwinStartup(typeof(SignalRWithWebForms.Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}