using Microsoft.Owin;
using Hangfire;
using Hangfire.MemoryStorage;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(StockAPI.App_Start.Startup))]

namespace StockAPI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Hangfire.GlobalConfiguration.Configuration.UseMemoryStorage();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
