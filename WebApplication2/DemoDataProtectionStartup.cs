using System.IO;
using System.Web.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.SystemWeb;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2
{
    public class DemoDataProtectionStartup : DataProtectionStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection()
                .SetApplicationName("demo")
                .PersistKeysToFileSystem(new DirectoryInfo(
                    Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "..", "keys")
                    ));
        }
    }
}