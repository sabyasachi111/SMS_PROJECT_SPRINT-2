using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMS_APP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS_APP.Controllers
{
    public class GradeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<GradeModel> gradeList = new List<GradeModel>();
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Grade"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    gradeList = JsonConvert.DeserializeObject<List<GradeModel>>(apiResponse);
                }
            }
            return View(gradeList);
        }

        //Method to add new grade
        public ViewResult AddGrade() => View();

        [HttpPost]
        public async Task<IActionResult> AddGrade(GradeModel gm)
        {
            GradeModel gModel = new GradeModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(gm), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Grade", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    gModel = JsonConvert.DeserializeObject<GradeModel>(apiResponse);
                }
            }
            return View(gModel);
        }

        //Method to update Grade details by patch
        [HttpGet]
        public async Task<IActionResult> UpdateGradePatch(long id)
        {
            GradeModel gm = new GradeModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Grade/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    gm = JsonConvert.DeserializeObject<GradeModel>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGradePatch(long id, GradeModel gm)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:44350/api/Grade/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"GradeName\", \"value\": \"" + gm.GradeName + "\"},{ \"op\": \"replace\", \"path\": \"Description\", \"value\": \"" + gm.Description + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return RedirectToAction("Index");
        }

        //Method to delete grade entry
        [HttpPost]
        public async Task<IActionResult> DeleteGrade(long GradeId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Grade/" + GradeId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
