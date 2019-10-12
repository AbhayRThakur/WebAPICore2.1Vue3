using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WebAPICore2_1VueCLI3.Middleware;

namespace WebAPICore2_1VueCLI3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // CORS specific for Net Core
        //readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // CORS specific for Net Core
            //services.AddCors(options => {
            //    options.AddPolicy(AllowSpecificOrigins, builder => {
            //        builder.WithOrigins("http://localhost:5000"); // Origin from Vue JS/API running parallely
            //    });
            //});

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                /*The default HSTS value is 30 days. 
                You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.*/
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            /*Handle client side routes. 
            This is imoprtant since we need to specify a web routing on server side 
            as it can't save history and unable to take Vue paths*/

            app.Run(async (context) => {
                context.Response.ContentType = "text/html";

                //For File path you can use "ClientApp/dist/index.html" if you are going to unit test/develop on local machine;
                await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html")); 
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //Replaced UseReactDevelopmentServer with Vue one in middleware extension file to accomodate Vue "serve"
                    spa.UseVueDevelopmentServer(npmScript: "serve");
                }
            });
        }
    }
}