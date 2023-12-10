namespace vezeeta_core.Data.Models
{
    public class doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public  string Email { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }
        public string Specialization_name { get; set; }
        public appointment Appointments { get; set; }
        public booking books { get; set; }
        public DateTime birthofdate { get; set; }
    }
}
