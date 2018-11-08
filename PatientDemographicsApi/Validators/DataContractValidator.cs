using System;
using System.Globalization;
using FluentValidation;
using PatientDemographicsApi.Config;
using PatientDemographicsApi.DataContract;

namespace PatientDemographicsApi.Validators
{
    namespace CarDataContractValidator
    {
        public class DataContractValidator : AbstractValidator<PatientInputDto>
        {
            public DataContractValidator()
            {
                RuleFor(p => p.Forename).NotNull().NotEmpty().Length(3, 50).WithMessage("Forename must be between 3 to 50 characters length");
                RuleFor(p => p.Surname).NotNull().NotEmpty().Length(2, 50).WithMessage("Surname must be between 2 to 50 characters length");
                RuleFor(p => p.DateOfBirth).NotNull().NotEmpty().Must(ValidBirthDate).WithMessage("Valid format for DateOfBirth is yyyy-MM-dd");
            }

            private bool ValidBirthDate(string dateTime)
            {
                return DateTime.TryParseExact(dateTime, Constants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtOut);
            }
        }        
    }
}
