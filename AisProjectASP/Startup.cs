using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AisProjectASP.Startup))]

namespace AisProjectASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
