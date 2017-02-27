using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Example_Web_Layer.Startup))]
namespace Example_Web_Layer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
