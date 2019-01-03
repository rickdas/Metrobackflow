using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using metrobackflow.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace metrobackflow
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //For Extra Security
            //goto securityheaders.com to check it
            app.UseHttpsRedirection();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseHsts(opt => opt.MaxAge(days: 365).IncludeSubdomains());
            app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
            app.UseXContentTypeOptions();
            app.UseXfo(opt => opt.SameOrigin());
            app.UseReferrerPolicy(opts => opts.NoReferrer());

            //Content-Security-Policy involved
            //app.UseCsp(options => options.DefaultSources(s => s.Self())
            //          .ScriptSources(s => s.Self().CustomSources("scripts.nwebsec.com"))
            //          .ReportUris(r => r.Uris("/report")));
            //app.UseCspReportOnly(options => options.DefaultSources(s => s.Self()).ImageSources(s => s.None()));
            //For Extra Security

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}