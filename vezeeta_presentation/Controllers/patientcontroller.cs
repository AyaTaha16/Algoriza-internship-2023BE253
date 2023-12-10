using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http.Headers;
using vezeeta.SERVICES;
using vezeeta_core.Data.Models;

namespace vezeeta_presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class patientcontroller : ControllerBase
    {
        private readonly IPatient _pai;
        public patientcontroller(IPatient pai)
        {
            _pai = pai;
        }
        [HttpPost]
        public IActionResult RegisterPatient(patient patie) {
            var log = _pai.RegisterPatient(patie);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }
        [HttpPost]
        public IActionResult Login(patient pat)
        {
            var log = _pai.Login(pat.Email, pat.Password);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);

        }
        [HttpGet]
        public IActionResult SearchDoctors(int page, int pageSize, string search) {
            var searchh = _pai.SearchDoctors(page, pageSize, search);
            if (searchh == null)
            {
                return NotFound();
            }
            return Ok(searchh);
        }
        [HttpPost]
        public IActionResult BookAppointment(Dictionary<DayOfWeek, TimeSpan> day, int pateintid, int doctorid, doctor specialization_name, decimal price, string discountcode, decimal finalprice, string status, bool isconfirmed)
        {
            var searchh = _pai.BookAppointment(day, pateintid, doctorid, specialization_name, price, discountcode, finalprice, status, isconfirmed);
            if (searchh == null)
            {
                return NotFound();
            }
            return Ok(searchh);
        }
        [HttpGet("{patientId}")]
        public IActionResult GetPatientBookings(int patientId) {
            var searchh = _pai.GetPatientBookings(patientId);
            if (searchh == null)
            {
                return NotFound();
            }
            return Ok(searchh);
        }
        [HttpPost("{bookingId}")]
        public IActionResult CancelBooking(int bookingId)
        {
            var searchh = _pai.CancelBooking(bookingId);
            if (searchh == null)
            {
                return NotFound();
            }
            return Ok(searchh);
        }
        [HttpGet("{doctorId}")]
        public IActionResult GetDoctorById(int doctorId)
        {
            var searchh = _pai.GetDoctorById(doctorId);
            if (searchh == null)
            {
                return NotFound();
            }
            return Ok(searchh);
        }

       

        
    }
}
