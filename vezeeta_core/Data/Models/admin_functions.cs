
namespace vezeeta_core.Data.Models
{
    public class admin_functions
    {
        public enum DiscoundType
        {
            Fixed,
            Percentage
        }

        public class DashboardStatistics
        {
            public int NumOfDoctors { get; set; }
            public int NumOfPatients { get; set; }
            public NumOfRequestsStatistics NumOfRequests { get; set; }
            public IEnumerable<SpecializationStatistics> Top5Specializations { get; set; }
            public IEnumerable<TopDoctorStatistics> Top10Doctors { get; set; }
        }

        public class NumOfRequestsStatistics
        {
            public int TotalRequests { get; set; }
            public int PendingRequests { get; set; }
            public int CompletedRequests { get; set; }
            public int CancelledRequests { get; set; }
        }

        public class SpecializationStatistics
        {
            public string Name { get; set; }
            public int NumOfRequests { get; set; }
        }

        public class TopDoctorStatistics
        {
            public string Image { get; set; }
            public string Name { get; set; }
            public string Specialization_name { get; set; }
            public int NumOfRequests { get; set; }
        }
    }
}
