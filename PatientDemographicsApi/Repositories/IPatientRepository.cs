using PatientDemographicsApi.Model;
using System;
using System.Collections.Generic;

namespace PatientDemographicsApi.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> Get();
        bool CanSave(Patient patient);
        Patient Get(Guid patientId);
    }
}
