using static vezeeta_core.Data.Models.admin_functions;

namespace vezeeta_core.Data.Models
{
    public class DiscoundCodeCoupon
    {
        public int Id { get; set; }
        public string DiscoundCode { get; set; }
        public int CompletedRequests { get; set; }
        public DiscoundType DiscoundType { get; set; }
        public bool IsActive { get; set; }
        public decimal Value { get; set; }
    }
}
