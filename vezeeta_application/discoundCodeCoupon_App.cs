using vezeeta_core;
using vezeeta_core.Data.Models;
using static vezeeta_core.Data.Models.admin_functions;
using vezeeta.SERVICES;


namespace vezeeta_application
{

 
    public class discoundCodeCoupon_App : admin_App,IDiscoundCodeCoupon
    {
        public DiscoundCodeCoupon AddDiscoundCodeCoupon( string discoundCode, int completedRequests, DiscoundType discoundType, decimal value)
        {
            var dis_code = new admin_App();
            var retun_val = dis_code.AddDiscoundCodeCoupon( discoundCode,  completedRequests, discoundType, value);
            return retun_val;
        }

        public bool DeactivateDiscoundCodeCoupon(int id)
        {
            var dis_code = new admin_App();
            var retun_val = dis_code.DeactivateDiscoundCodeCoupon(id);
            return retun_val;
        }

        public bool DeleteDiscoundCodeCoupon(int id)
        {
            var dis_code = new admin_App();
            var retun_val = dis_code.DeleteDiscoundCodeCoupon(id);
            return retun_val;
        }

        public bool UpdateDiscoundCodeCoupon(int id, string discoundCode, int completedRequests, admin_functions.DiscoundType discoundType, decimal value)
        {
            var dis_code = new admin_App();
            var retun_val = dis_code.UpdateDiscoundCodeCoupon(id,  discoundCode,  completedRequests,  discoundType,  value);
            return retun_val;
        }
    }
}
