using System.Collections.Generic;

namespace PatientDemographics.DataContract
{
    public class PatientInputDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<TelephoneNumberDto> TelephoneNumbers { get; set; }
    }
}
