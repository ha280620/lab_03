using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab_03.Startup))]
namespace lab_03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
