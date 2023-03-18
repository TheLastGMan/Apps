using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nfdc.Web.Startup))]
namespace Nfdc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
