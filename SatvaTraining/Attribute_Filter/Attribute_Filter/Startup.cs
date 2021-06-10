using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Attribute_Filter.Startup))]
namespace Attribute_Filter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
