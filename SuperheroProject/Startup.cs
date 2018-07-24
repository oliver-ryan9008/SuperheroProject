using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperheroProject.Startup))]
namespace SuperheroProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
