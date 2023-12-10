using System.Collections.Generic;
using vezeeta_core.Data.Models;
using vezeeta_core;
using vezeeta.SERVICES;
using Microsoft.EntityFrameworkCore;
using vezeeta_core.Data;

namespace vezeeta_application
{
    public class patient_App : booking_App,IPatient
    {
        private readonly List<patient> patients = new List<patient>();
        private readonly List<doctor> doctors = new List<doctor>();
        private readonly List<booking> bookings = new List<booking>();
        private readonly List<appointment> appointments = new List<appointment>();
        private readonly List<DiscoundCodeCoupon> discounds = new List<DiscoundCodeCoupon>();
        private readonly List<admin_functions> admin_function = new List<admin_functions>();
        public bool BookAppointment(Dictionary<DayOfWeek,TimeSpan>dic, int pateintid, int doctorid, doctor specialization_name, decimal price, string discountcode, decimal finalprice, string status, bool isconfirmed)
        {
            var book_appoint = new booking_App();
            var retun_val = book_appoint.BookAppointment(dic, pateintid, doctorid, specialization_name, price, discountcode, finalprice, status, isconfirmed);
                       return retun_val;
        }

        public bool CancelBooking(int bookingId)
        {
            var book_appoint = new booking_App();
            var retun_val = book_appoint.CancelBooking(bookingId);
                return retun_val;

        }


        public doctor GetDoctorById(int doctorId)
        {
           /* var doc = doctors.Find(d => d.DoctorId == id);
            if (doc == null)
            {

                throw new FileNotFoundException($"doctor with ID {id} not found.");
            }
            return doc;*/
            var book_doc = new booking_App();
            var retun_val = book_doc.GetDoctorById(doctorId);
            return retun_val;

        }



        public IEnumerable<booking> GetPatientBookings(int patientId)
        {
            var book_patient = new booking_App();
            var retun_val = book_patient.GetPatientBookings(patientId);
            return retun_val;

        }

        public bool Login(string email, string password)
        {
            using (var dbContext = new AppDbContext())
            {
                
                bool patientExists = dbContext.patients.Any(p => p.Email == email && p.Password == password);
                if (!patientExists)
                {
                    Console.WriteLine("email not Exists");
                    

                    return false;
                }

                return true; 
            }
        }

        public bool RegisterPatient(patient patient)
        {
            using (var dbContext = new AppDbContext())
            {
                // Check if a patient with the same email already exists
                bool emailExists = dbContext.patients.Any(p => p.Email == patient.Email);
                if (emailExists)
                {
                    Console.WriteLine("emailExists");
                    
                    return false;
                }

                
                dbContext.patients.Add(patient);
                dbContext.SaveChanges();

                return true; 
            }
        }

        public IEnumerable<doctor> SearchDoctors(int page, int pageSize, string search)
        {
            var search_doc = new booking_App();
            var retun_val = search_doc.GetAllDoctors( page,  pageSize,  search);
            return retun_val;

        }


    }
}
