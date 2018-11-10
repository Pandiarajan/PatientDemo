using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientDemographics.Models
{
    public class PatientViewModel
    {
        public Guid Id { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Forename { get; set; }
        [Required, StringLength(50, MinimumLength = 2)]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"(((19|20)\d\d)-(0[1-9]|1[0-2])-((0|1)[0-9]|2[0-9]|3[0-1]))$", ErrorMessage = "Invalid date format.")]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public virtual List<TelephoneNumber> TelephoneNumbers { get; set; }
    }
}
