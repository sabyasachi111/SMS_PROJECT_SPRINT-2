using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using SMS_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SMS_APP.Controllers
{
    public class FeeController : Controller
    {

        //Index Methods. Get all records for Fees
        public async Task<IActionResult> Index()
        {
            List<FeeModel> feeList = new List<FeeModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Fee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    feeList = JsonConvert.DeserializeObject<List<FeeModel>>(apiResponse);
                }
            }
            return View(feeList);
        }


        //Method to add a new fee
        public ViewResult AddFee() => View();

        [HttpPost]
        public async Task<IActionResult> AddFee(FeeModel fee)
        {
            FeeModel received = new FeeModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(fee), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Fee/", content))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //received = JsonConvert.DeserializeObject<StudentModel>(apiResponse);

                }
            }
            return View(received) ;
        }




        //Method To get Fees data By ID
        public ViewResult GetFeesById() => View();

        [HttpPost]
        public async Task<IActionResult> GetFeesById(long id)
        {
            FeeModel Fee = new FeeModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Fee/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Fee = JsonConvert.DeserializeObject<FeeModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return new Rotativa.AspNetCore.ViewAsPdf("GetFeesById", Fee) { FileName = "Invoice.pdf" };
                
        }


        //Method to delete a fee
        [HttpPost]
        public async Task<IActionResult> DeleteFee(long Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Fee/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
