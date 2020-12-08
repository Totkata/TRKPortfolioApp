using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TRKPortfolio.Web.Areas.Identity.IdentityHostingStartup))]

namespace TRKPortfolio.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
