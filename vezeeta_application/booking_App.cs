using vezeeta_core;
using vezeeta_core.Data.Models;
using vezeeta.SERVICES;
using System.Reflection;
using vezeeta_core.Data;

using Microsoft.EntityFrameworkCore;

namespace vezeeta_application
{
    public class booking_App : admin_App, IBooking

    {
        private readonly List<patient> patients = new List<patient>();
        private readonly List<doctor> doctors = new List<doctor>();
        private readonly List<booking> bookings = new List<booking>();
        private readonly List<appointment> appointments = new List<appointment>();
        private readonly List<DiscoundCodeCoupon> discounds = new List<DiscoundCodeCoupon>();
        private readonly List<admin_functions> admin_function = new List<admin_functions>();

        public bool BookAppointment(Dictionary<DayOfWeek, TimeSpan> day,int pateintid, int doctorid, doctor specialization_name, decimal price, string discountcode, decimal finalprice, string status, bool isconfirmed)
        {
            using (var dbContext = new AppDbContext())
            {
                var newbookadded = new booking();
                var booapp = newbookadded.appointment.day;
                    if (booapp==day){
                    throw new FileNotFoundException("can not book");
                    return newbookadded.appointment.is_availabe = false;
                }
                newbookadded.appointment.day=day;
                newbookadded.Specialization_name = specialization_name;
                newbookadded.Price=price;
                newbookadded.DiscountCode = discountcode;
                newbookadded.DoctorId = doctorid;
                newbookadded.PatientId = pateintid;
                newbookadded.FinalPrice = finalprice;
                return true;
                dbContext.bookings.Add(newbookadded);
                dbContext.SaveChanges();

            }
        }

        public bool CancelBooking(int bookingId)
        {
            using (var dbContext = new AppDbContext())
            {
                var booking_var = bookings.Find(k => k.Id== bookingId);
                
                if (booking_var == null)
                {
                    throw new FileNotFoundException($"booking with ID {bookingId} not found.");
                    return false;
                }

                booking_var.Iscanceled = true; 
                

                dbContext.SaveChanges(); 

                return true; 
            }

        }

        public IEnumerable<booking> GetAllBookings(int page, int pageSize, int search)
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<booking> query = dbContext.bookings;

                if (search!=null)
                {

                    query = query.Where(d => d.Id==search||d.PatientId==search);
                }


                int skipCount = (page - 1) * pageSize;


                var book_var = query.Skip(skipCount).Take(pageSize).ToList();

                return book_var;
            }
        }

        public booking GetBookingById(int bookingId)
        {
            var bok = bookings.Find(b => b.Id == bookingId);
            if (bok == null)
            {

                throw new FileNotFoundException($"booking with ID {bookingId} not found.");
            }
            return bok;
        }

        public IEnumerable<booking> GetDoctorBookings(int doctorId)
        {

            using (var dbContext = new AppDbContext())
            {
                var bookings = dbContext.bookings
                    .Where(b => b.DoctorId == doctorId)
                    .ToList();

                return bookings;
            }
        }

        public IEnumerable<booking> GetPatientBookings(int patientId)
        {

            using (var dbContext = new AppDbContext())
            {
                var bookings = dbContext.bookings
                    .Where(b => b.PatientId == patientId)
                    .ToList();

                return bookings;
            }
        }

        public bool UpdateBooking(int id, int patientid, int doctorid, appointment Aappointment, doctor specialization_name, decimal price, bool isconfirmed, string discountCode, decimal finalprice, string status)
        {
            using (var dbContext = new AppDbContext())
            {
                var bo = bookings.Find(b => b.Id ==id);
                if (bo != null)
                {
                    bo.Id=id;
                    bo.PatientId= patientid;
                    bo.DoctorId= doctorid;
                    bo.Specialization_name= specialization_name;
                    bo.appointment= Aappointment;
                    bo.Price= price;
                    bo.IsConfirmed= isconfirmed;
                    bo.DiscountCode= discountCode;
                    bo.FinalPrice= finalprice;
                    bo.Status= status;


      
                    return true;
                }

                bookings.Add(bo);

                dbContext.SaveChanges();
                return false;

            }
        }
    }
}
