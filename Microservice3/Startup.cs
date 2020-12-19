using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Entities;
using Microservice3.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Consul;
using Microsoft.OpenApi.Models;

namespace Microservice3
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
            var connection = Configuration.GetConnectionString("Constr");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IRepository3, Repository3>();
            services.AddControllers();
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(o => o.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Sector Api",
                Version = "v1"
            }));
            services.AddCors();
            services.AddSingleton<IConsulClient, ConsulClient>(options => new ConsulClient(config =>
            {
                config.Address = new Uri(Configuration["ConsulConfig:Host"]);
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var client = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var registration = new AgentServiceRegistration()
            {
                Address = "localhost",
                Port = 50680,
                Name = Configuration["ConsulConfig:ServiceName"],
                ID = Configuration["ConsulConfig:ServiceId"]
            };
            var applifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            applifetime.ApplicationStarted.Register(() => client.Agent.ServiceRegister(registration).ConfigureAwait(true));
            applifetime.ApplicationStopped.Register(() => client.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true));
            app.UseSwagger();
            app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Sector Api"));
            app.UseRouting();
            app.UseCors(settings => settings.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
