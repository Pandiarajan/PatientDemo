namespace PatientDemographics.Repository
{
    public class PatientXml
    {
        public PatientXml(string xmlData)
        {
            PatientData = xmlData;
        }

        public string PatientData { get; set; }
    }
}
