using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.DataProtection;

namespace WebApplication3
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Environment = env;
        }

        public IWebHostEnvironment Environment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddAntiforgery(opt =>
                {
                    opt.HeaderName = null;
                    opt.FormFieldName = "__RequestVerificationToken";
                    opt.Cookie.Name = "__RequestVerificationToken";
                })
                .AddDataProtection()
                .SetApplicationName("demo")
                .PersistKeysToFileSystem(new DirectoryInfo(
                    Path.Combine(Environment.ContentRootPath, "..", "keys")
                ));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
