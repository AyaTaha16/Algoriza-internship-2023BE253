namespace vezeeta_core.Data.Models
{
    public class booking
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public appointment appointment { get; set; }
        public doctor  Specialization_name { get; set; }
        public decimal Price { get; set; }
        public bool IsConfirmed { get; set; }
        public bool Ispending { get; set; }
        public bool Iscanceled { get; set; }

        public string DiscountCode { get; set; }
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }
    }
}
