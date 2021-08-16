using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            //    .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.AddWebOptimizer(x =>
            {
                x.AddScssBundle("/site.css", "/scss/_site.scss");
                x.CompileScssFiles();

                x.AddJavaScriptBundle("/lib.js", new string[] {
                    "/clrs-theme/lib/jquery-3.6.0.js",
                    "/clrs-theme/lib/bootstrap-4.6.0/dist/js/bootstrap.bundle.js",
                    "/clrs-theme/lib/kendo.all.min.2020.2.617.js",
                    "/clrs-theme/lib/kendo.aspnetmvc.min.2020.2.617.js",
                    "/clrs-theme/lib/jszip.min.js"
                    //"/lib/axios/axios.js",
                    //"/lib/progress/kendo-all-vue-wrapper/dist/cdn/kendo-all-vue-wrapper.js",
                    //"/lib/microsoft/signalr/dist/browser/signalr.js",
                    //"/lib/vue/vue.js"
                });

                x.AddJavaScriptBundle("/site.js", "/js/**/*.js");
            });

            services.AddRazorPages();

            //services.AddRazorPages().AddMvcOptions(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebOptimizer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
