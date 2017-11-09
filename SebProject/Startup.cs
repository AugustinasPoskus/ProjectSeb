using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SebProject.Startup))]
namespace SebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
