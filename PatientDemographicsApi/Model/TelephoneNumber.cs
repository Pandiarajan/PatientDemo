﻿namespace PatientDemographicsApi.Model
{
    public class TelephoneNumber
    {
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }

        public TelephoneNumber(string number, PhoneType phoneType)
        {
            Number = number;
            PhoneType = phoneType;
        }
    }
}
