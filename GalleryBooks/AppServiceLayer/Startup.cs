using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServiceLayer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IBooksRepositoryDAL<Books>, BooksRepositoryDAL>();
            services.AddScoped<IAdminRepositoryDAL<Admins>, AdminRepositoryDAL>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Books API",
                    Description = "Books Management API",
                    TermsOfService = new Uri("https://TechFeedSolutions.com/Privacy.html"),
                    Contact = new OpenApiContact
                    {
                        Name = "shubham sah",
                        Email = "shubham.sah@stridelysolutions.com",
                        Url = new Uri("https://LinkedIn.com/TechFeedSolutions"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "TechFeed Solutions Open License",
                        Url = new Uri("https://TechFeedSolutions.com"),
                    }
                });

            });
            //Default Policy
            services.AddCors(options => {
                options.AddDefaultPolicy(
                    builder => {
                        builder.WithOrigins("http://localhost:50520", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                        // builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //Named Policy
            services.AddCors(options => {
                options.AddPolicy(name: "AllowOrigin",
                    builder => {
                        builder.WithOrigins("http://localhost:50520", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                    });
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
            //default policy
            app.UseCors();
            //named policy
            app.UseCors("AllowOrigin");




            //app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

