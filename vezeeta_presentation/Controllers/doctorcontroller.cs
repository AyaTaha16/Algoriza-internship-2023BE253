using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using vezeeta.SERVICES;
using vezeeta_core.Data.Models;

namespace vezeeta_presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class doctorcontroller :  ControllerBase
    {
        /* private readonly HttpClient _httpClient;
         private readonly string _baseUrl;*/
        private readonly IDoctor _doctorr;

        public doctorcontroller(IDoctor doctorr)
        {
            _doctorr = doctorr;
        }
        [HttpPost]
        public IActionResult Login(doctor docs) {
            var log= _doctorr.Login(docs.Email,docs.Password);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);

        }

        [HttpGet("{doctorId}")]
        public IActionResult GetAllBookings(int doctorId, Dictionary<DayOfWeek, TimeSpan> searchDate, int pageSize, int pageNumber)
 
        {
            var doctor = _doctorr.GetAllBookings(doctorId,searchDate,pageSize,pageNumber);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);

        }
        [HttpPost("{bookingId}")]
        public IActionResult ConfirmCheckUp(int bookingId) {
            bool doc = _doctorr.ConfirmCheckUp(bookingId);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        [HttpPost("{doctorId}")]
        public IActionResult AddAppointment(int doctorId , Dictionary<DayOfWeek, TimeSpan> appointment)
        {
            bool doc = _doctorr.AddAppointment( doctorId ,  appointment);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        [HttpPost("{doctorId}")]
        public IActionResult UpdateAppointment(doctor doctor, Dictionary<DayOfWeek, TimeSpan> updatedAppointment)
        {
            bool doc = _doctorr.UpdateAppointment(doctor.DoctorId, doctor.Appointments, updatedAppointment);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc);
        }
        [HttpPost("{appointmentTime}")]
        public IActionResult DeleteAppointment(int doctorId, Dictionary<DayOfWeek, TimeSpan> appointmentTime)
        {
            bool doc = _doctorr.DeleteAppointment(doctorId, appointmentTime);
            
            return Ok(doc);
        }

    }
}
