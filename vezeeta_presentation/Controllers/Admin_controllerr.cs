using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static vezeeta_core.Data.Models.admin_functions;
using System.Net.Http.Headers;
using vezeeta_core.Data.Models;


namespace vezeeta_presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_controllerr : ControllerBase
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://api.vezeeta.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Call the API endpoints
                await GetDashboardStatistics();
                await GetAllDoctors();
                await GetDoctorById(1);
                await AddDoctor(new doctor
                {
                    Image = "doctor.jpg",
                    Name = "John",
                    Email = "johndoe@example.com",
                    Mobile = "1234567890",
                    Specialization_name = "Cardiology",
                    Gender = "Male",
                    birthofdate = new DateTime(1980, 1, 1)
                });
                await EditDoctor(new doctor
                {
                    DoctorId = 1,
                    Image = "doctor.jpg", 
                    Name = "Doe",
                    Email = "johndoe@example.com",
                    Mobile = "1234567890",
                    Specialization_name = "Cardiology",
                    Gender = "Male",
                    birthofdate = new DateTime(1980, 1, 1)
                });
                await DeleteDoctor(1);
                await GetAllPatients();
                await GetPatientById(1);
                await AddDiscountCode(new DiscoundCodeCoupon
                {
                    DiscoundCode = "DISCOUNT123",
                    CompletedRequests = 10,
                    DiscoundType = DiscoundType.Percentage,
                    Value = 10
                });
                await UpdateDiscountCode(new DiscoundCodeCoupon
                {
                    Id = 1,
                    DiscoundCode = "DISCOUNT123",
                    CompletedRequests = 10,
                    DiscoundType = DiscoundType.Percentage,
                    Value = 10
                });
                await DeleteDiscountCode(1);
                await DeactivateDiscountCode(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }

        static async Task GetDashboardStatistics()
        {
            HttpResponseMessage response = await client.GetAsync("admin/dashboard");
            response.EnsureSuccessStatusCode();

            var dashboardStats = await response.Content.ReadAsAsync<DashboardStatistics>();

            Console.WriteLine($"Number of Doctors: {dashboardStats.NumOfDoctors}");
            Console.WriteLine($"Number of Patients: {dashboardStats.NumOfPatients}");
            Console.WriteLine($"Number of Requests: {dashboardStats.NumOfRequests}");
            Console.WriteLine($"Top 5 Specializations:");
            foreach (var specialization in dashboardStats.Top5Specializations)
            {
                Console.WriteLine($"{specialization.Name}: {specialization.NumOfRequests}");
            }
            Console.WriteLine($"Top 10 Doctors:");
            foreach (var doctor in dashboardStats.Top10Doctors)
            {
                Console.WriteLine($"{doctor.Image}, {doctor.Name}, {doctor.Specialization_name}, {doctor.NumOfRequests}");
            }
        }

        static async Task GetAllDoctors()
        {
            HttpResponseMessage response = await client.GetAsync("doctors");
            response.EnsureSuccessStatusCode();

            var doctors = await response.Content.ReadAsAsync<List<doctor>>();

            foreach (var doctor in doctors)
            {
                Console.WriteLine($"{doctor.Image}, {doctor.Name}, {doctor.Email}, {doctor.Mobile}, {doctor.Specialization_name}, {doctor.Gender}");
            }
        }

        static async Task GetDoctorById(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"doctors/{id}");
            response.EnsureSuccessStatusCode();

            var doctor = await response.Content.ReadAsAsync<doctor>();

            Console.WriteLine($"{doctor.Image}, {doctor.Name}, {doctor.Email}, {doctor.Specialization_name}, {doctor.Gender}, {doctor.birthofdate}");
        }

        static async Task AddDoctor(doctor doctor)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("doctors", doctor);
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                
                Console.WriteLine("Doctor added successfully.");
            }
        }

        static async Task EditDoctor(doctor doctor)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"doctors/{doctor.DoctorId}", doctor);
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Doctor updated successfully.");
            }
        }

        static async Task DeleteDoctor(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"doctors/{id}");
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Doctor deletedsuccessfully.");
            }
        }

        static async Task GetAllPatients()
        {
            HttpResponseMessage response = await client.GetAsync("patients");
            response.EnsureSuccessStatusCode();

            var patients = await response.Content.ReadAsAsync<IEnumerable<patient>>();

            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Image}, {patient.Name}, {patient.Email}, {patient.Mobile}, {patient.Gender}, {patient.Date_of_birth}");
            }
        }

        static async Task GetPatientById(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"patients/{id}");
            response.EnsureSuccessStatusCode();

            var patient = await response.Content.ReadAsAsync<patient>();

            Console.WriteLine($"{patient.Image}, {patient.Name}, {patient.Email}, {patient.Mobile}, {patient.Gender}, {patient.Specialization_name}");

            Console.WriteLine("Requests:");
            foreach (var request in patient.books)
            {
                Console.WriteLine($", {request.DoctorId}, {request.Specialization_name}, {request.appointment.day.Keys}, {request.appointment.day.Values}, {request.Price}, {request.DiscountCode}, {request.FinalPrice}, {request.Status}");
            }
        }

        static async Task AddDiscountCode(DiscoundCodeCoupon discountCode)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("settings/discountcodes", discountCode);
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Discount code added successfully.");
            }
        }

        static async Task UpdateDiscountCode(DiscoundCodeCoupon discountCode)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"settings/discountcodes/{discountCode.Id}", discountCode);
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Discount code updated successfully.");
            }
        }

        static async Task DeleteDiscountCode(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"settings/discountcodes/{id}");
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Discount code deleted successfully.");
            }
        }

        static async Task DeactivateDiscountCode(int id)
        {
            HttpResponseMessage response = await client.PutAsync($"settings/discountcodes/{id}/deactivate", null);
            response.EnsureSuccessStatusCode();

            bool success = await response.Content.ReadAsAsync<bool>();

            if (success)
            {
                Console.WriteLine("Discount code deactivated successfully.");
            }
        }
    }
}
