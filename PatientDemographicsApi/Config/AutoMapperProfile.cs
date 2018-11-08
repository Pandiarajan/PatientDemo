using AutoMapper;
using PatientDemographicsApi.DataContract;
using PatientDemographicsApi.Model;

namespace PatientDemographicsApi.Config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, PatientOutputDto>()
                .ForMember(dto => dto.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToShortDateString()));

            CreateMap<DataContract.TelephoneNumber, Model.TelephoneNumber>()
                .ForMember(model => model.Number, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(model => model.PhoneType, opt => opt.MapFrom(src => Model.PhoneType.Get((int)src.PhoneType)));
        }
    }
}
