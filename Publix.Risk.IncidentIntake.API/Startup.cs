using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Publix.Risk.IncidentIntake.API.Pipelines;
using Publix.Risk.IncidentIntake.Application;
using Publix.Risk.IncidentIntake.Application.Core;
using Publix.Risk.IncidentIntake.Domain.Core;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using Publix.Risk.IncidentIntake.Persistence.Core.IO;
using Publix.Risk.IncidentIntake.Persistence.Core.Repository.Context;
using Publix.Risk.IncidentIntake.Persistence.Repository;


namespace Publix.Risk.IncidentIntake.API
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
            services.AddSwaggerGen();

            // Add MVC Health Checks
            services.AddHealthChecks();

            // Add HTTP client.
            services.AddHttpClient();

            services.AddSingleton((obj) => Configuration);
            services.AddScoped<IConfig, ConfigRepository>();

            services.AddMediatR(typeof(Startup), typeof(DomainLayer));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            services.AddDbContext<RMXSecurity>(options =>
                options.UseSqlServer(
                    Configuration["RMXSecurity_ConnectionString"],
                    b => b.MigrationsAssembly(typeof(RMXSecurity).Assembly.FullName)));
            services.AddScoped<IRMXSecureContext>(provider => provider.GetService<RMXSecurity>());

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

            services.AddScoped<ILogger, DbLogger>();

            services.AddScoped<IAPILoginRepository, LoginRepository>();
            services.AddScoped<IAssureClaimsRepository, AssureClaimsRepository>();
            services.AddScoped<IPDF_IO, PDF_IO>();
            services.AddScoped<IPDFService, PDFService>();
            services.AddScoped<IPublixSendMailService, PublixSendMailService>();

            // Graph and Azure Identity services
            //services.AddScoped<IAuthenticationProvider, DelegateAuthenticationProvider>();
            //services.AddScoped<DelegateAuthenticationProvider, MyProviderDelegate>();

            // ASP.NET services
            services
                .AddControllers(x => x.Filters.Add(new ValidationExceptionFilter()));

            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
