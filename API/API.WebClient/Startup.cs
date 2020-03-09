using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.WebClient.Clients;
using GraphQL.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace API.WebClient
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
            //.AddNewtonsoftJson(options =>
            //{
            //    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});
            .AddJsonOptions(options => { });
            services.AddSingleton(t => new GraphQLClient(this.config["ApiWebClientUri"]));
            services.AddSingleton<ProductGraphClient>();
            services.AddHttpClient<ProductHttpClient>(o => o.BaseAddress = new Uri(this.config["ApiWebClientUri"]));
            services.AddSingleton<SupplierGraphClient>();
            services.AddHttpClient<SupplierHttpClient>(o => o.BaseAddress = new Uri(this.config["ApiWebClientUri"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapAreaControllerRoute(
                //    "User",
                //    "User",
                //    "User/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{productId?}");

                endpoints.MapControllerRoute(
                    name: "Suppliers",
                    pattern: "{controller=Supplier}/{action=Index}/{supplierId?}");
            });
        }
    }
}
