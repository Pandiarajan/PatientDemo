using Microsoft.Extensions.DependencyInjection;
using PatientDemographics.Repository;

namespace PatientDemo.Config
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<ISerializer, Serializer>()
                .AddScoped<ApiContext, ApiContext>()
                .AddScoped<IPatientRepository, PatientRepository>();
        }        
    }
}
