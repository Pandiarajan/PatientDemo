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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientXml>().Property(e => e.Id).ValueGeneratedOnAdd();
        }

        public DbSet<PatientXml> Patients { get; set; }
    }
}
