using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.Services;
using BaltaStore.Infra.StoreContext.DataContexts;
using BaltaStore.Infra.StoreContext.Repositories;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using BaltaStore.Shared;

namespace BaltaStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "BaltaStore", Version = "v1" });
            });

            services.AddElmahIo(x =>
            {
                x.ApiKey = "8a32ade931884030a681fd4061fc19da";
                x.LogId = new Guid("3832dd02-c713-4a1c-a037-502af64fefcd");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta Store - V1"));

            app.UseElmahIo();
        }
    }
}
