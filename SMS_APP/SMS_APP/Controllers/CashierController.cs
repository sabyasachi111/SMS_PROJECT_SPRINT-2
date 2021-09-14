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
    public class CashierController : Controller
    {
        //Index Methods. Gets all data from cashier database
        public async Task<IActionResult> Index()
        {
            List<CashierModel> cashierList = new List<CashierModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Cashier"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cashierList = JsonConvert.DeserializeObject<List<CashierModel>>(apiResponse);
                }
            }
            return View(cashierList);
        }


        //Method To get Cashier data By ID
        public ViewResult GetCashierById() => View();

        [HttpPost]
        public async Task<IActionResult> GetCashierById(long id)
        {
            CashierModel cashier = new CashierModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Cashier/" + id))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cashier = JsonConvert.DeserializeObject<CashierModel>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(cashier);
        }


        //Method to create a new Cashier record
        public ViewResult AddCashier() => View();

        [HttpPost]
        public async Task<IActionResult> AddCashier(CashierModel cashier)
        {
            CashierModel received = new CashierModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cashier), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44350/api/Cashier/", content))
                {
                    //string apiResponse = await response.Content.ReadAsStringAsync();
                    //received = JsonConvert.DeserializeObject<CashierModel>(apiResponse);

                }
            }
            return View(received) ;
        }



        //Method to update the cashier data
        public async Task<IActionResult> UpdateCashierPatch(long id)
        {
            CashierModel reservation = new CashierModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44350/api/Cashier/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<CashierModel>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCashierPatch(long id, CashierModel reservation)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:44350/api/Cashier/" + id),
                    Method = new HttpMethod("Patch"),
                    Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"cashierId\", \"value\": \"" + reservation.CashierId + "\"},{ \"op\": \"replace\", \"path\": \"cashierName\", \"value\": \"" + reservation.CashierName + "\"}]", Encoding.UTF8, "application/json")
                };

                var response = await httpClient.SendAsync(request);
            }
            return View(reservation);
        }


        //Method to Delete Cashier Database
        [HttpPost]
        public async Task<IActionResult> DeleteCashier(long Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44350/api/Cashier/" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
