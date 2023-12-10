using System.ComponentModel.DataAnnotations;

namespace vezeeta_core.Data.Models
{
    public class patient:booking
    {
        public int patientId { get; set; }
      
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public long Image { get; set; }
        public string Date_of_birth { get; set; }
        public string Specialization_name { get; set; }
        public int Discound_code { get; set; }
        public appointment Appointment { get; set; }
        public List<booking> books { get; set; }
    }
}
