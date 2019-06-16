using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ToysApiApplication.Email;
using ToysApplication.Commands;
using ToysApplication.Interfaces;
using ToysEfCommands;
using ToysEfDataAccess;

namespace ToysApiApplication
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
            services.AddDbContext<ToysContext>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IGetProductCommand, EfGetProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IEditProductCommand, EfEditProductCommand>();
            services.AddTransient<IGetOneProductCommand, EfGetOneProductCommand>();

            services.AddTransient<IGetCategoryCommand, EfGetCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EfEditCategoryCommand>();

            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IGetOneUserCommand, EfGetOneUserCommand>();

            services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();

            services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();
            services.AddTransient<IGetImageCommand, EfGetImageCommand>();


            var section = Configuration.GetSection("Email");
            var email = new SmptEmail(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);
            services.AddSingleton<IEmail>(email);


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
