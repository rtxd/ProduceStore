using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UTS.ProduceStore.WebFrontEnd.Startup))]
namespace UTS.ProduceStore.WebFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
