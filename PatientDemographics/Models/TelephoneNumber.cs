using System.ComponentModel.DataAnnotations;

namespace PatientDemographics.Models
{
    public class TelephoneNumber
    {
        public PhoneType PhoneType { get; set; }
        [Range(1000000, 99999999999, ErrorMessage ="Phone number must be atleast 7 digit and maximum 11 digit, no special characters allowed.")]
        public string PhoneNumber { get; set; }
    }
}
