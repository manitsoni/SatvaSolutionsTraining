using Hangfire;
using Hangfire_Demo.Controllers;
using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(Hangfire_Demo.Startup))]
namespace Hangfire_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            HomeController obj = new HomeController();
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            app.UseHangfireDashboard("/myJobDashboard", new DashboardOptions());
            RecurringJob.AddOrUpdate(() => obj.EmailSend(), "*/10 * * * *");
            //RecurringJob.AddOrUpdate(() => obj.SMSSend(), Cron.Minutely);
            app.UseHangfireServer();
        }
    }
}
