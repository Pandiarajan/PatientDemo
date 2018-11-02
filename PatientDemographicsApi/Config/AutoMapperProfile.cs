using AutoMapper;
using PatientDemographicsApi.DataContract;
using PatientDemographicsApi.Model;

namespace PatientDemographicsApi.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString()));
        }
    }
}
