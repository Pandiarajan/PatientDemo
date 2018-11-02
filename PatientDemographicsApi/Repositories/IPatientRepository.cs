using PatientDemographicsApi.Model;
using System.Collections.Generic;

namespace PatientDemographicsApi.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Get();
    }
}
