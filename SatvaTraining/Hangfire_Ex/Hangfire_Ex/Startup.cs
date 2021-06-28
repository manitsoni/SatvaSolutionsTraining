using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
namespace Hangfire_Ex
{
    public class Startup
    {
        public void Configure(IAppBuilder app)
        {
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}