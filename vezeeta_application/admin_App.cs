using static vezeeta_core.Data.Models.admin_functions;
using vezeeta_core.Data.Models;
using vezeeta.SERVICES;
using vezeeta_core.Data;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.Numerics;


namespace vezeeta_application
{
    public class admin_App : Iadmin
    {


        private readonly List<doctor> doctors = new List<doctor>();
        private readonly List<booking> bookings = new List<booking>();
        private readonly List<appointment> appointments = new List<appointment>();
        private readonly List<DiscoundCodeCoupon> discounds = new List<DiscoundCodeCoupon>();
        private readonly List<admin_functions> admin_function = new List<admin_functions>();
        private readonly List<patient> patients = new List<patient>();

        public DiscoundCodeCoupon AddDiscoundCodeCoupon(string discoundCode, int completedRequests, admin_functions.DiscoundType discoundType, decimal value)
        {
            using (var dbContext = new AppDbContext())
            {
                var coupon = new DiscoundCodeCoupon
                {
                    DiscoundCode = discoundCode,
                    CompletedRequests = completedRequests,
                    DiscoundType = discoundType,
                    Value = value
                };
                return coupon;
                dbContext.DiscoundCodeCoupons.Add(coupon);
                dbContext.SaveChanges();

            }
        }
        public bool AddDoctor(string image, string Name, string email, string phone, string specialize, string gender, DateTime dateOfBirth)
        {
            using (var dbContext = new AppDbContext())
            {
                var newdoctoradded = new doctor
                {
                    Name = Name,
                    Gender = gender,
                    Email = email,
                    Mobile = phone,
                    Image = image,
                    Specialization_name = specialize,
                    birthofdate = dateOfBirth


                };
                return true;
                dbContext.doctors.Add(newdoctoradded);
                dbContext.SaveChanges();

            }
        }

        public bool DeactivateDiscoundCodeCoupon(int id)
        {
            using (var dbContext = new AppDbContext()) {
                var discountCode = dbContext.DiscoundCodeCoupons.Find(id);

                if (discountCode == null)
                {

                    return false;
                }

                discountCode.IsActive = false;

                dbContext.SaveChanges();

                return true;
            }

        }

        public bool DeleteDiscoundCodeCoupon(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var discountCode = dbContext.DiscoundCodeCoupons.Find(id);

                if (discountCode == null)
                {
                    Console.WriteLine("already not found ");
                    return true;
                }

                discounds.Remove(discountCode);

                dbContext.SaveChanges();

                return true;
            }

        }

        public bool DeleteDoctor(int id)
        {
            using (var dbContext = new AppDbContext())
            {
                var doc = dbContext.doctors.Find(id);

                if (doc == null)
                {
                    Console.WriteLine("already not found ");
                    return true;
                }

                doctors.Remove(doc);

                dbContext.SaveChanges();

                return true;
            }
        }

        public IEnumerable<doctor> GetAllDoctors(int page, int pageSize, string search)
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<doctor> query = dbContext.doctors;

                if (!string.IsNullOrEmpty(search))
                {

                    query = query.Where(d => d.Name.Contains(search) || d.Specialization_name.Contains(search));
                }


                int skipCount = (page - 1) * pageSize;


                var doctors_var = query.Skip(skipCount).Take(pageSize).ToList();

                return doctors_var;
            }
        }

        public IEnumerable<patient> GetAllPatients(int page, int pageSize, string search)
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<patient> query = dbContext.patients;

                if (!string.IsNullOrEmpty(search))
                {

                    query = query.Where(p => p.Name.Contains(search) || p.Specialization_name.Contains(search));
                }


                int skipCount = (page - 1) * pageSize;


                var patient_var = query.Skip(skipCount).Take(pageSize).ToList();

                return patient_var;
            }
        }

        public admin_functions.DashboardStatistics GetDashboardStatistics()
        {

            //var dashboardStatistics = admin.GetDashboardStatistics();

            //var dashboardStatisticsDto = admin.Map<DashboardStatistics>(dashboardStatistics);
            //return dashboardStatisticsDto;
            var boo = new booking();
            var CompletedRequest = 0;
            var CancelledRequest = 0;
            var PendingRequest = 0;
            if (boo.IsConfirmed == true) {
                CompletedRequest = CompletedRequest + 1;
            }
            else if (boo.IsConfirmed == null)
                PendingRequest = PendingRequest + 1;
            else
                CancelledRequest = CancelledRequest + 1;

            var response = new DashboardStatistics
            {
                NumOfDoctors = doctors.Count,
                NumOfPatients = patients.Count,
                NumOfRequests = new NumOfRequestsStatistics
                {
                    TotalRequests = bookings.Count,

                    PendingRequests = PendingRequest,
                    CompletedRequests = CompletedRequest,
                    CancelledRequests = CancelledRequest
                },
                Top5Specializations = new List<SpecializationStatistics>
        {
            new SpecializationStatistics
            {
                Name = "Cardiology",
                NumOfRequests = 50
            },
            new SpecializationStatistics
            {
                Name = "Dermatology",
                NumOfRequests = 40
            },

        },
                Top10Doctors = new List<TopDoctorStatistics>
        {
            new TopDoctorStatistics
            {
                Image = "doctor1.jpg",
                Name = "John Doe",
                Specialization_name = "Cardiology",
                NumOfRequests = 30
            },
            new TopDoctorStatistics
            {
                Image = "doctor2.jpg",
                Name = "Jane Smith",
                Specialization_name = "Dermatology",
                NumOfRequests = 25
            },

        }
            };

            return response;
        }

        public doctor GetDoctorById(int id)
        {
            /*var getdoc= doctors.FirstOrDefault(d =>d.DoctorId  == id);
            return getdoc;*/

            var doc = doctors.Find(d => d.DoctorId == id);
            if (doc == null)
            {

                throw new FileNotFoundException($"doctor with ID {id} not found.");
            }
            var docinfo = new doctor
            {
                DoctorId = doc.DoctorId,
                Name = doc.Name,
                Image = doc.Image,
                Email = doc.Email,
                Mobile = doc.Mobile,
                Gender = doc.Gender,
                birthofdate = doc.birthofdate,

            };

            return docinfo;
        }
    public patient GetPatientById(int id)
    {
            var patie = patients.Find(p => p.patientId == id);
            if (patie == null)
        {

            throw new FileNotFoundException($"Patient with ID {id} not found.");
        }
        var patientinfo = new patient
        {
            Image = patie.Image,
            Name = patie.Name,
            Email = patie.Email,
            Mobile = patie.Mobile,
            Gender = patie.Gender,
            Date_of_birth = patie.Date_of_birth,
            books = bookings.Select(r => new booking
            {

                DoctorId = r.DoctorId,
                Specialization_name = r.Specialization_name,
                appointment = r.appointment,

                Price = r.Price,
                DiscountCode = r.DiscountCode,
                FinalPrice = r.FinalPrice,
                Status = r.Status
            }).ToList()
        };
        return patientinfo;
    }




    public bool UpdateDiscoundCodeCoupon(int id, string discoundCode, int completedRequests, DiscoundType discoundType, decimal value)
    {
        using (var dbContext = new AppDbContext())
        {
            var discoundcode_var = discounds.Find(d => d.Id == id);
            if (discoundcode_var != null)
            {
                discoundcode_var.DiscoundCode = discoundCode;
                discoundcode_var.DiscoundType = discoundType;
                discoundcode_var.CompletedRequests = completedRequests;
                discoundcode_var.Value = value;




                return true;
            }

            discounds.Add(discoundcode_var);

            dbContext.SaveChanges();
            return false;

        }
    }

    public bool UpdateDoctor(int id, string image, string name, string email, string phone, string specialize, string gender, DateTime dateOfBirth)
    {
        using (var dbContext = new AppDbContext())
        {
            var doc = doctors.Find(d => d.DoctorId == id);
            if (doc != null)
            {
                doc.Email = email;
                doc.Image = image;
                doc.Name = name;
                doc.Specialization_name = specialize;
                doc.Mobile = phone;
                doc.Gender = gender;
                doc.birthofdate = dateOfBirth;
                return true;
            }

            doctors.Add(doc);

            dbContext.SaveChanges();
            return false;

        }
    }

}
    
}
