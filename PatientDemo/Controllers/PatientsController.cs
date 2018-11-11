using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientDemo.Config;
using PatientDemographics.DataContract;
using PatientDemographics.Domain;
using PatientDemographics.Repository;

namespace PatientDemographicsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public IEnumerable<PatientOutputDto> Get()
        {
            return _mapper.Map<IEnumerable<PatientOutputDto>>(_patientRepository.Get());
        }

        [HttpGet("{patientId}")]
        public PatientOutputDto Get(int patientId)
        {
            return _mapper.Map<PatientOutputDto>(_patientRepository.Get(patientId));
        }

        [HttpPost]
        public int Post([FromBody] PatientInputDto patientDto)
        {
            Patient patient = new Patient(patientDto.Forename, 
                patientDto.Surname, 
                DateTime.ParseExact(patientDto.DateOfBirth, Constants.DateFormat, CultureInfo.InvariantCulture), 
                Gender.GetGender(patientDto.Gender), 
                _mapper.Map<List<TelephoneNumber>>(patientDto.TelephoneNumbers));

            if (_patientRepository.Get(patient.Id) == null)
            {
                _patientRepository.Save(patient);
                return patient.Id;
            }
            else
                return 0;
        }
    }
}
