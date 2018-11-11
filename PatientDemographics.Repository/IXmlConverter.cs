using PatientDemographics.Domain;

namespace PatientDemographics.Repository
{
    public interface IXmlConverter
    {
        string GetXml(Patient patient);
        Patient GetPatient(string patientXml);
    }
}
