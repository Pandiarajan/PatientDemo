﻿using System;

namespace PatientDemographicsApi.DataContract
{
    public class PatientDto
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}