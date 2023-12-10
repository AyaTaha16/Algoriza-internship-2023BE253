using vezeeta_core.Data.Models;
using vezeeta_core;
using static vezeeta_core.Data.Models.appointment;

namespace vezeeta.SERVICES
{
    public interface IPatient
    {
        bool RegisterPatient(patient patient);
        bool Login(string email, string password);
        IEnumerable<doctor> SearchDoctors(int page, int pageSize, string search);
        bool BookAppointment(Dictionary<DayOfWeek, TimeSpan> day, int pateintid, int doctorid, doctor specialization_name, decimal price, string discountcode, decimal finalprice, string status, bool isconfirmed);
        IEnumerable<booking> GetPatientBookings(int patientId);
        bool CancelBooking(int bookingId);
        doctor GetDoctorById(int doctorId);
        
       
        
        

    }
}
