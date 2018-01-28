using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using api.commons;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api
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
            services.AddDbContext<TrainingContext>(options => options.UseInMemoryDatabase("tasks"));
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.Formatting = Formatting.Indented);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(route =>
            {
                route.MapRoute("default", "api/{controller}/{action}/{id?}");
            });

            var context = app.ApplicationServices.GetService<TrainingContext>();
            LoadTestData(context);
        }

        //TODO prepare csv with test data
        private static void LoadTestData(TrainingContext context)
        {
            context.TrainingTasks.Add(new TrainingTask());
            context.TrainingTasks.Add(new TrainingTask());
        }
    }
}
