using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientDemographics.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Forename { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public virtual List<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}
