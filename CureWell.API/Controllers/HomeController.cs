using CureWell.Data;
using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CureWell.API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ApiController
    {
        private readonly ICureWellRepository cureWellRepository;

        //public HomeController(ICureWellRepository cureWellRepository)
        //{
        //    this.cureWellRepository = cureWellRepository;
        //}

        [HttpGet]
        [Route("doctors")]
        public IHttpActionResult GetDoctors()
        {
            var data = cureWellRepository.GetAllDoctors();
            return Ok(data);
        }

        [HttpGet]
        [Route("specializations")]
        public IHttpActionResult Get()
        {
            var data = cureWellRepository.GetAllSpecialization();
            return Ok(data);
        }

        [HttpGet]
        [Route("surgeries")]
        public IHttpActionResult GetAllSurgeryTypeForToday()
        {
            var data = cureWellRepository.GetAllSurgeries();
            return Ok(data);
        }

        [HttpGet]
        [Route("specializations/{specializationCode}/doctors")]
        public IHttpActionResult GetDoctorsBySpecializationCode(string specializationCode)
        {
            var data = cureWellRepository.GetDoctorsBySpecializationCode(specializationCode);
            return Ok(data);
        }

        [HttpPost]
        [Route("doctors")]
        public IHttpActionResult AddDoctor(Doctor doctor)
        {
            bool success = cureWellRepository.AddDoctor(doctor);
            if (success)
                return Created("/", doctor);
            else
            {
                return BadRequest("Doctor details could not be added");
            }
        }

        [HttpPut()]
        [Route("doctors")]
        public IHttpActionResult UpdateDoctorDetails(Doctor dObj)
        {
            var success = cureWellRepository.UpdateDoctorDetails(dObj);
            if (success)
                return Ok();
            else
                return BadRequest();

        }

        [HttpPut]
        [Route("surgeries")]
        public IHttpActionResult UpdateSurgery(Surgery SObj)
        {
            var success = cureWellRepository.UpdateSurgery(SObj);
            if (success)
                return Ok();
            else
                return BadRequest();

        }

        [HttpDelete]
        [Route("doctors")]
        public IHttpActionResult DeleteDoctor(Doctor dObj)
        {
            var success = cureWellRepository.DeleteDoctor(dObj);
            if (success)
                return Ok();
            else
                return BadRequest();
        }

    }
}
