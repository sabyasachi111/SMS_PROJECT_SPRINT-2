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
    public class AttendanceController : Controller
    {
        //Index method- Get all data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AttendanceModel> AttendanceList = new List<AttendanceModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Attendance"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    AttendanceList = JsonConvert.DeserializeObject<List<AttendanceModel>>(apiResponse);
                }
            }
            return View(AttendanceList);
        }

        //Method to add new attendacne entry
        public ViewResult AddAttendance() => View();

        [HttpPost]
        public async Task<IActionResult> AddAttendance(AttendanceModel attn)
        {
            AttendanceModel Attendance = new AttendanceModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(attn), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Attendance", content))
                {

                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //Attendance = JsonConvert.DeserializeObject<AttendanceModel>(apiResponse);

                }

            }
            return View(Attendance);
        }


        //Method to update the Attendance 
        public async Task<IActionResult> UpdateAttendancePatch(long id)
        {
            AttendanceModel Attendance = new AttendanceModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Attendance/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Attendance = JsonConvert.DeserializeObject<AttendanceModel>(apiResponse);
                }
            }
            return View(Attendance);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAttendancePatch(long id, AttendanceModel attendance)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:44350/api/Attendance/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"attendanceDate\", \"value\": \"" + attendance.AttendanceDate + "\"},{\"op\": \"replace\",\"path\": \"attended\", \"value\": \"" + attendance.Attended + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return View(attendance);
        }


        //Method to Delete Attendance from Database
        [HttpPost]
        public async Task<IActionResult> DeleteAttendance(long Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Attendance/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
