using vezeeta_core.Data.Models;
using vezeeta_core;
namespace vezeeta.SERVICES;

public interface IBooking
{
    IEnumerable<booking> GetAllBookings(int page, int pageSize, int search);
    booking GetBookingById(int bookingId);
    IEnumerable<booking> GetDoctorBookings(int doctorId);
    IEnumerable<booking> GetPatientBookings(int patientId);
    bool BookAppointment(Dictionary<DayOfWeek, TimeSpan> day, int pateintid, int doctorid, doctor specialization_name, decimal price, string discountcode, decimal finalprice, string status, bool isconfirmed);
    bool UpdateBooking(int id, int patientid, int doctorid, appointment Aappointment, doctor specialization_name, decimal price, bool isconfirmed, string discountCode, decimal finalprice, string status);
    bool CancelBooking(int bookingId);
}
