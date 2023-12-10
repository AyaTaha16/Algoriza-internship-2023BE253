using static vezeeta_core.Data.Models.admin_functions;
using vezeeta_core.Data.Models;
using vezeeta_core;
namespace vezeeta.SERVICES
{
    public interface IDiscoundCodeCoupon
    {
        bool UpdateDiscoundCodeCoupon(int id, string discoundCode, int completedRequests, admin_functions.DiscoundType discoundType, decimal value);
        DiscoundCodeCoupon AddDiscoundCodeCoupon( string discoundCode, int completedRequests, DiscoundType discoundType, decimal value);
        bool DeleteDiscoundCodeCoupon(int id);
        bool DeactivateDiscoundCodeCoupon(int id);
    }
}
