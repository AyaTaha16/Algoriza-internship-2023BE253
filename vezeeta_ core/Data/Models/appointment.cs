namespace vezeeta_core.Data.Models
{
    public class appointment:booking
    {
        public bool is_availabe { get; set; }

        //for doctors
        public int ID { get; set; }
        public decimal Price { get; set; }
        public enum days
        {  Saturday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
}
        public Dictionary<DayOfWeek, TimeSpan> day { get; set; }
        public  TimeSpan times { get; set; }
        
    }
}
