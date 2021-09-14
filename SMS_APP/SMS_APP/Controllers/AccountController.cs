using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SMS_APP.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(long loginId, string password, int role)
        {
            //if (!string.IsNullOrEmpty(password))
            //{
            //    return RedirectToAction("Login");
            //}
            ClaimsIdentity identity = null;
            //bool isAuthenticate = false;


            //sql connection for id password matching
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-OOOQ7DSK\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=True;");
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM LOGIN WHERE LOGIN_ID = {loginId} AND PASSWORD = '{password}' AND ROLE = {role}; ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() != "1")
            {
                RedirectToAction("Login", "Account");
            }

            //if (loginId == 100001 && password == "a" && role == 1)
            if (dt.Rows[0][0].ToString() == "1" && role == 1)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,loginId.ToString()),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                //isAuthenticate = true;
            }

            //if (loginId == 200001 && password == "b" && role == 2)
            if (dt.Rows[0][0].ToString() == "1" && role == 2)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginId.ToString()),
                    new Claim(ClaimTypes.Role,"Teacher")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                //isAuthenticate = true;
            }

            //if (loginId == 300001 && password == "c" && role == 3)
            if (dt.Rows[0][0].ToString() == "1" && role == 3)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, loginId.ToString()),
                    new Claim(ClaimTypes.Role,"Cashier")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                //isAuthenticate = true;                               
            }


            if (dt.Rows[0][0].ToString() == "1" && role == 1)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Admin", "Home");
            }

            else if (dt.Rows[0][0].ToString() == "1" && role == 2)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Teacher", "Home");
            }

            else if(dt.Rows[0][0].ToString() == "1" && role == 3)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Cashier", "Home");
            }
            else if(role != 1 || role != 2 || role !=3)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
            
        }
    }
}
