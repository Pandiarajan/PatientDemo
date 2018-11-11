using Microsoft.EntityFrameworkCore;
using PatientDemographics.Domain;

namespace PatientDemographics.Repository
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<PatientXml> Patients { get; set; }
    }
}
