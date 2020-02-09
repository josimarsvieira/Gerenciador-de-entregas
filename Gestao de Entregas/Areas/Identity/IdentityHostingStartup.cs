using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Gestao_de_Entregas.Areas.Identity.IdentityHostingStartup))]

namespace Gestao_de_Entregas.Areas.Identity
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