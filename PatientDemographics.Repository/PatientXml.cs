using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientDemographics.Repository
{
    public class PatientXml
    {
        public PatientXml()
        {
        }
        public PatientXml(string xmlData)
        {
            PatientData = xmlData;
        }

        public string PatientData { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
