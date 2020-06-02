﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoApplication.DataManager;
using TodoApplication.Models;
using TodoApplication.Repository;
using Swashbuckle.AspNetCore.Swagger;

using System.Text;

namespace TodoApplication
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddSwaggerGen()
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1", new Info { Title = "My API", Version = "v1" });
            });
            services.AddDbContext<TodoDBContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient(typeof(ITodoRepository<Models.Task, long>), typeof(TodoService));
            // services.AddTransient(typeof(ITodoRepository<Models.Task, long>), typeof(TodoService));
            //services.AddTransient<ITodoRepository, TodoService>();
            //var mapper = config.CreateMapper();
            //services.AddSingleton(mapper);
            //services.AddTransient<TodoService>();
            // Register the Swagger generator, defining one or more Swagger documents  
          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
              //Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();

          
        }
    }
}
