using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using json=Newtonsoft.Json.Serialization;

namespace dotnetcoreapi.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(o => { 
                    o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; 
                    
                });
            services.AddMvc(options => { 
                options.EnableEndpointRouting = false;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
            //services.AddMvc()
                .AddJsonOptions(o => {
                    //o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                    o.JsonSerializerOptions.WriteIndented = true;
                });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseStatusCodePages();
            app.UseMvc();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
