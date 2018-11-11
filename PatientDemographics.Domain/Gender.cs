using System.Collections.Generic;
using System.Linq;

namespace PatientDemographics.Domain
{
    public class Gender
    {
        public static Gender Male = new Gender(1, "Male");
        public static Gender Female = new Gender(2, "Female");
        public static Gender Others = new Gender(3, "Others");
        private static IEnumerable<Gender> GenderList = new[] { Male, Female, Others };
        public Gender(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Gender GetGender(string gender)
        {
            return GenderList.FirstOrDefault(g => g.Name == gender);
        }

        public int Id { get; }
        public string Name { get; }
    }
}
