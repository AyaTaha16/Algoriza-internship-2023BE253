using System.Numerics;
using vezeeta_core.Data.Models;
using vezeeta_core;
namespace vezeeta.SERVICES
{
    public interface IDoctor
    {
        bool Login(string email, string password);
        IEnumerable<booking> GetAllBookings(int doctorId, Dictionary<DayOfWeek, TimeSpan>  searchDate, int pageSize, int pageNumber);
        bool ConfirmCheckUp(int bookingId);
        bool AddAppointment(int doctorId, Dictionary<DayOfWeek, TimeSpan> appointment);
        bool UpdateAppointment(int doctorId,  appointment appointmentTime, Dictionary<DayOfWeek, TimeSpan> updatedAppointment);
        bool DeleteAppointment(int doctorId,  Dictionary<DayOfWeek, TimeSpan> appointmentTime);
    }
}
