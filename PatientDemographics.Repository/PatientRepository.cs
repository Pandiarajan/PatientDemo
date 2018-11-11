using System.Collections.Generic;
using System.Linq;
using PatientDemographics.Domain;

namespace PatientDemographics.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ISerializer _serializer;
        private readonly ApiContext _apiContext;

        public PatientRepository(ISerializer serializer, ApiContext apiContext)
        {
            _serializer = serializer;
            _apiContext = apiContext;
        }
        public void Save(Patient patient)
        {
            var xmlData = _serializer.Serialize(patient);
            var xmlPatient = new PatientXml(xmlData);
            _apiContext.Patients.Add(xmlPatient);
            _apiContext.SaveChanges();
            patient.Id = xmlPatient.Id;//Auto generated id.
        }

        public IEnumerable<Patient> Get()
        {
            foreach (var patientXml in _apiContext.Patients)
            {
                var patient = _serializer.Deserialize<Patient>(patientXml.PatientData);
                patient.Id = patientXml.Id;
                yield return patient;
            }
        }

        public Patient Get(int id)
        {
            var patientXml = _apiContext.Patients.FirstOrDefault(p => p.Id == id);
            if (patientXml == null)
                return null;
            var patient = _serializer.Deserialize<Patient>(patientXml.PatientData);
            patient.Id = id;
            return patient;
        }
    }
}
