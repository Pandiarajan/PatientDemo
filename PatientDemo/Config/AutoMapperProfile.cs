using AutoMapper;
using PatientDemographics.DataContract;
using PatientDemographics.Domain;

namespace PatientDemo.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientOutputDto>()
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToString("yyyy-MMM-dd")));

            CreateMap<TelephoneNumberDto, TelephoneNumber>()
                .ForMember(model => model.Number, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(model => model.PhoneType, opt => opt.MapFrom(src => PhoneType.Get((int)src.PhoneType)));
        }
    }
}
