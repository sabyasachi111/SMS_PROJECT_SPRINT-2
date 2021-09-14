using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMS_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS_APP.Controllers
{
    public class TeacherController : Controller
    {
        //Index Methods. Gets all data from teacher database
        public async Task<IActionResult> Index()
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Teacher"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    teacherList = JsonConvert.DeserializeObject<List<TeacherModel>>(apiResponse);
                }
            }
            return View(teacherList);
        }



        //Method To get teacher data By ID
        public ViewResult GetTeacherById() => View();

        [HttpPost]
        public async Task<IActionResult> GetTeacherById(long id)
        {
            TeacherModel teacher = new TeacherModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Teacher/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        teacher = JsonConvert.DeserializeObject<TeacherModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(teacher);
        }




        //Method to create a new Teacher record
        public ViewResult AddTeacher() => View();

        [HttpPost]
        public async Task<IActionResult> AddTeacher(TeacherModel teacher)
        {
            TeacherModel received = new TeacherModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Teacher/", content))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //received = JsonConvert.DeserializeObject<StudentModel>(apiResponse);

                }
            }
            return View(received) ;
        }




        //Method to update the teacher data
        public async Task<IActionResult> UpdateTeacherPatch(long id)
        {
            TeacherModel reservation = new TeacherModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Teacher/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<TeacherModel>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeacherPatch(long id, TeacherModel reservation)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:44350/api/Teacher/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"className\", \"value\": \"" + reservation.ClassName + "\"}," +
                        "{ \"op\": \"replace\", \"path\": \"teacherName\", \"value\": \"" + reservation.TeacherName + "\"},{ \"op\": \"replace\", \"path\": \"gender\", \"value\": \"" + reservation.Gender + "\"},{ \"op\": \"replace\", \"path\": \"dob\", \"value\": \"" + reservation.Dob + "\"}," +
                        "{ \"op\": \"replace\", \"path\": \"contact\", \"value\": \"" + reservation.Contact + "\"},{ \"op\": \"replace\", \"path\": \"email\", \"value\": \"" + reservation.Email + "\"},{ \"op\": \"replace\", \"path\": \"address\", \"value\": \"" + reservation.Address + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return View(reservation);
        }





        //Method to Delete teacher details
        [HttpPost]
        public async Task<IActionResult> DeleteTeacher(long Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Teacher/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
