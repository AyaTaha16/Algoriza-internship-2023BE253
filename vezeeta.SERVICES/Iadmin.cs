using System.Numerics;
using vezeeta_core.Data.Models;
using static vezeeta_core.Data.Models.admin_functions;
using vezeeta_core;
using vezeeta_core.Data;

namespace vezeeta.SERVICES
{
    public interface Iadmin
    {
        DashboardStatistics GetDashboardStatistics();
        IEnumerable<doctor> GetAllDoctors(int page, int pageSize, string search);
        doctor GetDoctorById(int id);
        public bool AddDoctor(string image, string Name, string email, string phone, string specialize, string gender, DateTime dateOfBirth);
        public bool UpdateDoctor(int id, string image, string name, string email, string phone, string specialize, string gender, DateTime dateOfBirth);
        bool DeleteDoctor(int id);
        IEnumerable<patient> GetAllPatients(int page, int pageSize, string search);
        patient GetPatientById(int id);
        DiscoundCodeCoupon AddDiscoundCodeCoupon(string discoundCode, int completedRequests, DiscoundType discoundType, decimal value);
        bool UpdateDiscoundCodeCoupon(int id, string discoundCode, int completedRequests, DiscoundType discoundType, decimal value);
        bool DeleteDiscoundCodeCoupon(int id);
        bool DeactivateDiscoundCodeCoupon(int id);
    }

    
}
    

