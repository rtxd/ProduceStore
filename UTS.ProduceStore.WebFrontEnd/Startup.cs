using Microsoft.Owin;
using Owin;
using System;
using System.IO;

[assembly: OwinStartupAttribute(typeof(UTS.ProduceStore.WebFrontEnd.Startup))]
namespace UTS.ProduceStore.WebFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\Data"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            ConfigureAuth(app);
        }
    }
}
