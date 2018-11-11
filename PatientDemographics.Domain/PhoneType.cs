using System.Collections.Generic;
using System.Linq;

namespace PatientDemographics.Domain
{
    public class PhoneType
    {
        public static PhoneType MobilePhone = new PhoneType(1, "MobilePhone");
        public static PhoneType HomePhone = new PhoneType(2, "HomePhone");
        public static PhoneType WorkPhone = new PhoneType(3, "WorkPhone");
        private static IEnumerable<PhoneType> PhoneNumberTypes = new[] { MobilePhone, HomePhone, WorkPhone };

        public PhoneType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
        public static PhoneType Get(int id)
        {
            return PhoneNumberTypes.FirstOrDefault(p => p.Id == id);
        }
    }
}