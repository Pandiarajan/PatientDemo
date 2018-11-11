using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace PatientDemographics.Domain
{
    public class PhoneType
    {
        public static PhoneType MobilePhone = new PhoneType(1, "MobilePhone");
        public static PhoneType HomePhone = new PhoneType(2, "HomePhone");
        public static PhoneType WorkPhone = new PhoneType(3, "WorkPhone");
        private static IEnumerable<PhoneType> PhoneNumberTypes = new[] { MobilePhone, HomePhone, WorkPhone };
        public PhoneType()
        {
        }
        public PhoneType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [XmlIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public static PhoneType Get(int id)
        {
            return PhoneNumberTypes.FirstOrDefault(p => p.Id == id);
        }
    }
}