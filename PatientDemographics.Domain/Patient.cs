using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PatientDemographics.Domain
{
    public class Patient
    {
        [XmlIgnore]
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set;}
        public List<TelephoneNumber> TelephoneNumbers { get; set; }

        public Patient()
        {

        }
        private Patient(string forename, string surname, DateTime dateOfBirth, 
            Gender gender)
        {
            Forename = forename;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
        public Patient(int id, string forename, string surname, DateTime dateOfBirth,
            Gender gender): this(forename, surname, dateOfBirth, gender)
        {
            Id = id;
        }

        public Patient(string forename, string surname, DateTime dateOfBirth,
            Gender gender, List<TelephoneNumber> telephoneNumbers): this(forename, surname, dateOfBirth, gender)
        {
            TelephoneNumbers = telephoneNumbers;
        }

        public Func<Patient, bool> IsDuplicate()
        {
            return p => p.Forename == Forename && p.Surname == Surname && p.DateOfBirth == DateOfBirth;
        }
    }
}
