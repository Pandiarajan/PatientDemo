using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PatientDemographicsApi.Model;
using PatientDemographicsApi.Repositories;
using System.Collections.Generic;

namespace PatientDemographicsApi.Config
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services.AddScoped<IPatientRepository, PatientXmlRepository>();
        }        
    }
}
