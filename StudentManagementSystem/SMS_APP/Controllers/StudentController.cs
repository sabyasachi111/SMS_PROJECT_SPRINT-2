using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SMS_APP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SMS_APP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }


        HttpClientHandler _clientHandler = new HttpClientHandler();
        //public IActionResult Index()
        //{
        //    return View();
        //}


        //Index Methods. Gets all data from student database
        public async Task<IActionResult> Index()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Student"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentList = JsonConvert.DeserializeObject<List<StudentModel>>(apiResponse);
                }
            }
            return View(studentList);
        }



        //Method To get student data By ID
        public ViewResult GetStudentById() => View();

        [HttpPost]
        public async Task<IActionResult> GetStudentById(long id)
        {
            StudentModel student = new StudentModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Student/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(student);
        }



        //Method to create a new Student record
        public ViewResult AddStudent() => View();

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentModel student)
        {
            StudentModel received = new StudentModel();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Student/", content))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //received = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
                    
                }
            }
            return RedirectToAction("Index"); ;
        }



        //Method to update the Data in Student table
        public async Task<IActionResult> UpdateStudentPatch(long id)
        {
            StudentModel reservation = new StudentModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Student/" + id))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //reservation = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudentPatch(long id, StudentModel reservation)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:44350/api/Student/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"className\", \"value\": \"" + reservation.ClassName + "\"}," +
                        "{ \"op\": \"replace\", \"path\": \"studentName\", \"value\": \"" + reservation.StudentName + "\"},{ \"op\": \"replace\", \"path\": \"gender\", \"value\": \"" + reservation.Gender + "\"},{ \"op\": \"replace\", \"path\": \"dob\", \"value\": \"" + reservation.Dob + "\"}," +
                        "{ \"op\": \"replace\", \"path\": \"bloodGroup\", \"value\": \"" + reservation.BloodGroup + "\"},{ \"op\": \"replace\", \"path\": \"contact\", \"value\": \"" + reservation.Contact + "\"},{ \"op\": \"replace\", \"path\": \"address\", \"value\": \"" + reservation.Address + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return RedirectToAction("Index");
        }



        //Method to Delete Student Database
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(long Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Student/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
