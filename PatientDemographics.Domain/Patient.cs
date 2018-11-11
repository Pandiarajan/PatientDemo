using System;
using System.Collections.Generic;

namespace PatientDemographics.Domain
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set;}
        public IList<TelephoneNumber> TelephoneNumbers { get; set; }
        public Patient(Guid id, string forename, string surname, DateTime dateOfBirth, 
            Gender gender)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
        public Patient(Guid id, string forename, string surname, DateTime dateOfBirth,
            Gender gender, IList<TelephoneNumber> telephoneNumbers): this(id, forename, surname, dateOfBirth, gender)
        {
            TelephoneNumbers = telephoneNumbers;
        }

        public Func<Patient, bool> IsDuplicate()
        {
            return p => p.Forename == Forename && p.Surname == Surname && p.DateOfBirth == DateOfBirth;
        }
    }
}
