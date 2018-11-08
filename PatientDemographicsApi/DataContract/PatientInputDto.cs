namespace PatientDemographicsApi.DataContract
{
    public class PatientInputDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; } //ISO Format.
        public string Gender { get; set; }
        public TelephoneNumber[] TelephoneNumbers { get; set; }
    }
}
