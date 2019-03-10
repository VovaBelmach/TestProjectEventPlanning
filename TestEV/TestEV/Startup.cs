using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestEV.Startup))]
namespace TestEV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
