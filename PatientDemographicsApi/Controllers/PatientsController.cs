using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientDemographicsApi.Config;
using PatientDemographicsApi.DataContract;
using PatientDemographicsApi.Model;
using PatientDemographicsApi.Repositories;

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
        public ActionResult<IEnumerable<PatientOutputDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PatientOutputDto>>(_patientRepository.Get()));
        }

        [HttpGet("{patientId}")]
        public ActionResult<PatientOutputDto> Get(Guid patientId)
        {
            return Ok(_mapper.Map<PatientOutputDto>(_patientRepository.Get(patientId)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PatientInputDto patientDto)
        {
            Patient patient = new Patient(Guid.NewGuid(), patientDto.Forename, 
                patientDto.Surname, 
                DateTime.ParseExact(patientDto.DateOfBirth, Constants.DateFormat, CultureInfo.InvariantCulture), 
                Gender.GetGender(patientDto.Gender), 
                _mapper.Map<Model.TelephoneNumber[]>(patientDto.TelephoneNumbers));

            if (_patientRepository.CanSave(patient))
                return Ok(patient.Id);
            else
                return Conflict(patientDto);
        }
    }
}
