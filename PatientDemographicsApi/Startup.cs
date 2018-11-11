using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using PatientDemographicsApi.Config;
using PatientDemographicsApi.Validators.CarDataContractValidator;
using PatientDemographics.Repository;
using Microsoft.EntityFrameworkCore;

namespace PatientDemographicsApi
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
            services.AddDbContext<ApiContext>(opt => opt.UseSqlite("Data Source=Patients.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation(f => f.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(DataContractValidator))))
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services
                .AddDependencies()
                .AddAutoMapper();
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
