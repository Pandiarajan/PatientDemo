using System;
using System.Collections.Generic;

namespace PatientDemographicsApi.Model
{
    public class Patient
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set;}
        public IList<TelephoneNumber> TelephoneNumbers { get; set; }
        public Patient(string forename, string surname, DateTime dateOfBirth, Gender gender, IList<TelephoneNumber> telephoneNumbers)
        {
            Forename = forename;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            TelephoneNumbers = telephoneNumbers;
        }
    }
}
