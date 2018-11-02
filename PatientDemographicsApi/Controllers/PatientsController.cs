using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<PatientDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PatientDto>>(_patientRepository.Get()));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PatientInputDto patient)
        {

        }
    }
}
