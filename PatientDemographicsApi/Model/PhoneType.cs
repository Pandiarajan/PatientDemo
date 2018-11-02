namespace PatientDemographicsApi.Model
{
    public class PhoneType
    {
        public static PhoneType MobilePhone = new PhoneType(1, "MobilePhone");
        public static PhoneType HomePhone = new PhoneType(2, "HomePhone");
        public static PhoneType WorkPhone = new PhoneType(3, "WorkPhone");

        public PhoneType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}