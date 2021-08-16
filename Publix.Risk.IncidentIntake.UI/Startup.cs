using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.Graph;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Persistence;
using Publix.Risk.IncidentIntake.Persistence.IO;
using Publix.Risk.IncidentIntake.Persistence.Repository;
using Publix.Risk.IncidentIntake.Persistence.Repository.Context;
using Publix.Risk.IncidentIntake.UI.Pipelines;
using Serilog;
using System;
using System.Net.Http;
using System.Reflection;

namespace Publix.Risk.IncidentIntake.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(@"\Logs\S0RMXPBX\IncidentIntake\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information($"Starting IncidentIntake Web Application. {Assembly.GetExecutingAssembly().GetName().Version}");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpesctedly!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC Health Checks
            services.AddHealthChecks();

            services.AddLogging(logBuilder => logBuilder.AddSerilog(null, true));

            // Add HTTP client.
            services.AddHttpClient();

            services.AddSingleton((obj) => Configuration);
            services.AddSingleton((IConfiguration) => this.Configuration);

            services.AddMediatR(typeof(Startup), typeof(DomainLayer));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            services.AddDbContext<RMXContext>(options =>
                options.UseSqlServer(
                    Configuration["RMX_ConnectionString"],
                    b => b.MigrationsAssembly(typeof(RMXContext).Assembly.FullName)));
            services.AddScoped<IRMXContext>(provider => provider.GetService<RMXContext>());

            services.AddDbContext<PBXContext>(options =>
                options.UseSqlServer(
                    Configuration["PBX_ConnectionString"],
                    b => b.MigrationsAssembly(typeof(PBXContext).Assembly.FullName)));
            services.AddScoped<IPBXContext>(provider => provider.GetService<PBXContext>());

            services.AddScoped<IAssureClaimsRepository, AssureClaimsRepository>();
            services.AddScoped<IPDF_IO, PDF_IO>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddScoped<IPublixSendMailService, PublixSendMailService>();
            services.AddScoped<ILogger, DbLogger>();
            services.AddScoped<Microsoft.Extensions.Logging.ILogger, DbLogger>();

            // Graph and Azure Identity services
            //services.AddScoped<IAuthenticationProvider, DelegateAuthenticationProvider>();
            //services.AddScoped<DelegateAuthenticationProvider, MyProviderDelegate>();

            // ASP.NET services
            //services.AddControllers(x => x.Filters.Add(new ValidationExceptionFilter()));

            // HttpClientFactory
            services.AddHttpClient(Configuration["Client_Name"], client =>
            {
                client.BaseAddress = new Uri(Configuration["ProjectsAPIServer"]);
                //client.DefaultRequestHeaders.Add("APIKey", Configuration["APIKey"]);
                //client.DefaultRequestHeaders.Add("X-Version", Configuration["X-VERSION"]);
            });

            // HttpClientFactory will take care of connection caching, ProjectsAPI is the name 
            // of the factory, just above.
            services.AddSingleton<IHTTPClientHelper, HTTPClientHelper>(s =>
                         new HTTPClientHelper(s.GetService<IHttpClientFactory>(), Configuration["Client_Name"])
                         );

            services.AddMvc();
            //services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            //    .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.AddControllersWithViews(options =>
            {
            }).AddNewtonsoftJson();
            //services.AddControllersWithViews(options =>
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
