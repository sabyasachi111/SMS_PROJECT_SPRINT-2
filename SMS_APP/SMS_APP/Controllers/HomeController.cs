using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_APP.Controllers
{
    
    public class HomeController : Controller
    {

        [Authorize(Roles ="Admin")]
        public IActionResult Admin()
        {
            return View();
        }


        [Authorize(Roles ="Teacher")]
        public IActionResult Teacher()
        {
            return View();
        }


        [Authorize(Roles ="Cashier")]
        public IActionResult Cashier()
        {
            return View();
        }
    }
}
