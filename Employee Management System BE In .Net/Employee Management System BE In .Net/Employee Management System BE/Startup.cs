using CommonLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using ServiceLayer.Interface;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System_BE
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee_Management_System_BE", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration["ConnectionStrings:DBSettingConnection"]));

            #region Auth

            services.AddScoped<IAuthSL, AuthSL>();
            services.AddScoped<IAuthRL, AuthRL>();

            #endregion

            #region Designation

            services.AddScoped<IDesignationSL, DesignationSL>();
            services.AddScoped<IDesignationRL, DesignationRL>();

            #endregion

            #region Employee

            services.AddScoped<IEmployeeSL, EmployeeSL>();
            services.AddScoped<IEmployeeRL, EmployeeRL>();

            #endregion

            #region HourManagement

            services.AddScoped<IHourManagementSL, HourManagementSL>();
            services.AddScoped<IHourManagementRL, HourManagementRL>();

            #endregion

            #region Leave

            services.AddScoped<ILeaveSL, LeaveSL>();
            services.AddScoped<ILeaveRL, LeaveRL>();

            #endregion

            #region Payment

            services.AddScoped<IPaymentSL, PaymentSL>();
            services.AddScoped<IPaymentRL, PaymentRL>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee_Management_System_BE v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
