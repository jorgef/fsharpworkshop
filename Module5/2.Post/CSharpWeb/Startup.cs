using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpWeb.Startup))]
namespace CSharpWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
