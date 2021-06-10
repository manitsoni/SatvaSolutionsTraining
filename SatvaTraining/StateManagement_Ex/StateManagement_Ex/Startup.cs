using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StateManagement_Ex.Startup))]
namespace StateManagement_Ex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
