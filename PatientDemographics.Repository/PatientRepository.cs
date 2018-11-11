using System;
using System.Collections.Generic;
using System.Linq;
using PatientDemographics.Domain;

namespace PatientDemographics.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IXmlConverter _xmlConverter;
        private readonly ApiContext _apiContext;

        public PatientRepository(IXmlConverter xmlConverter, ApiContext apiContext)
        {
            _xmlConverter = xmlConverter;
            _apiContext = apiContext;
        }
        public void Save(Patient patient)
        {
            var xmlData = _xmlConverter.GetXml(patient);
            _apiContext.Patients.Add(new PatientXml(xmlData));
        }

        public IEnumerable<Patient> Get()
        {
            foreach (var patientXml in _apiContext.Patients)
            {
                yield return _xmlConverter.GetPatient(patientXml.PatientData);
            }
        }

        public Patient Get(Guid patientId)
        {
            return Get().FirstOrDefault(p => p.Id == patientId);
        }
    }
}
