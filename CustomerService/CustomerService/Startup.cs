using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CustomerService.repositories;
using CustomerService.CommandHandlers;
using CustomerService.Commands;
using CustomerService.Events;
using CustomerService.entities;

namespace CustomerService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkSqlServer().AddDbContext<customersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("customerconnection")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerCommand, CustomerCreatedCommand>();
            services.AddScoped<ICustomerCommandHandler, CustomerCommandHandler>();
            services.AddScoped<IEvents, CustomerCreatedEvent>();
            services.AddScoped<entity, CustomerEntity>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
