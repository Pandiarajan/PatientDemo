using Microsoft.Extensions.DependencyInjection;
using PatientDemographics.Repository;

namespace PatientDemographicsApi.Config
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IXmlConverter, XmlConverter>()
                .AddScoped<IPatientRepository, PatientRepository>();
        }        
    }
}
