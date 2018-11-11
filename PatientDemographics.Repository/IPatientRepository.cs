using PatientDemographics.Domain;
using System.Collections.Generic;

namespace PatientDemographics.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Get();
        void Save(Patient patient);
        Patient Get(int patientId);
    }
}
