using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CyberShopeeMVC.Models;

namespace CyberShopeeMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult SignIn()
        {
            //Response.ContentType = "application/json";
            return View("SignIn");
        }

        [HttpPost]
        public ActionResult SignIn(Customer customer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44349/api/Customer");
            //var postTask = client.PostAsJsonAsync<Customer>("Customer", customer);
           
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Successful";
                return View("SignIn");
            }
            ViewBag.Message = "Incorrect username or password";
            return View("SignIn");
        }
    }
}