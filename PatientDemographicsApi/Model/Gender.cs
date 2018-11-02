namespace PatientDemographicsApi.Model
{
    public class Gender
    {
        public static Gender Male = new Gender(1, "Male");
        public static Gender Female = new Gender(2, "Female");
        public static Gender Others = new Gender(3, "Others");

        public Gender(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
