using System;
using System.Collections.Generic;
using System.Linq;
using vezeeta_core;
using vezeeta_core.Data.Models;

using vezeeta.SERVICES;
using vezeeta_core.Data;
using Microsoft.EntityFrameworkCore;

namespace vezeeta_application
{
   
    public class doctor_App : booking_App,IDoctor
    {
        private readonly List<patient> patients = new List<patient>();
        private readonly List<doctor> doctors = new List<doctor>();
        private readonly List<booking> bookings = new List<booking>();
        private readonly List<appointment> appointments = new List<appointment>();
        private readonly List<DiscoundCodeCoupon> discounds = new List<DiscoundCodeCoupon>();
        private readonly List<admin_functions> admin_function = new List<admin_functions>();
        public bool AddAppointment(int doctorId, Dictionary<DayOfWeek, TimeSpan> appointment)
        {
            using (var dbContext = new AppDbContext())
            {
                var doctor = doctors.Find(a => a.DoctorId== doctorId);

                if (doctor == null)
                {
                    return false;
                }

                doctor.Appointments.appointment.day=appointment; 
                dbContext.SaveChanges();

                return true; 
            }
        }

        public bool ConfirmCheckUp(int bookingId)
        {
            using (var dbContext = new AppDbContext())
            {
                var bookingvar =bookings.Find(k => k.Id == bookingId);

                if (bookingvar == null)
                {
                    throw new FileNotFoundException($"booking with ID {bookingId} not found.");
                    return false;
                }

                bookingvar.IsConfirmed = true; 

                dbContext.SaveChanges(); 

                return true; 
            }
        }

        public bool DeleteAppointment(int doctorId, Dictionary<DayOfWeek, TimeSpan> appointmentTime)
        {
            using (var dbContext = new AppDbContext())
            {
                
                var docvar = doctors.Find(k => k.DoctorId == doctorId);

                if (docvar == null)
                {
                    throw new FileNotFoundException($"doctor with ID {doctorId} not found.");
                    return false;
                }
                var apor = doctors.Find(x => x.Appointments.day.Keys == appointmentTime.Keys&&x.Appointments.day.Values==appointmentTime.Values);
                if (apor == null) {
                    throw new FileNotFoundException($"appointment {appointmentTime} not found.");
                    return false;
                }
                doctors.Remove(apor);
                dbContext.SaveChanges();

                return true;
            }
        }

        public IEnumerable<booking> GetAllBookings(int doctorId, Dictionary<DayOfWeek, TimeSpan>  searchDate, int pageSize, int pageNumber)
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<booking> query = dbContext.bookings.Where(b => b.DoctorId == doctorId);
                query = query.Where(b => b.appointment.day == searchDate);
                int skipCount = (pageNumber - 1) * pageSize;

                var bookings = query.OrderBy(b => b.appointment.day).Skip(skipCount).Take(pageSize).ToList();

                return bookings;
            }
        }

        public bool Login(string email, string password)
        {
            using (var dbContext = new AppDbContext())
            {

                bool doctorExists = dbContext.doctors.Any(p => p.Email == email && p.Password == password);
                if (!doctorExists)
                {
                    Console.WriteLine("email not Exists");


                    return false;
                }

                return true;
            }
        }

        public bool UpdateAppointment(int doctorId, appointment  appointmentTime, Dictionary<DayOfWeek, TimeSpan> updatedAppointment)
        {

            using (var dbContext = new AppDbContext())
            {
                var doctor_var = dbContext.doctors.Find(doctorId);

                if (doctor_var == null)
                {

                    return false;
                }
                var appointment = doctors.Find(a => a.Appointments.day.Keys == appointmentTime.day.Keys && a.Appointments.day.Values == appointmentTime.day.Values);

                    if (appointment == null)
                    {

                        return false;
                    }
                    if (updatedAppointment.Values == (appointment.Appointments.day.Values))
                    {
                        return false;
                    }
                    appointment.Appointments.day = updatedAppointment;
                

                return true;
                dbContext.SaveChanges();
            } 
        }
    }
}
       