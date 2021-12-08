using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Controllers
{
    
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Bookinger", "Admin");
        }

        public IActionResult Bookinger()
        {
            return View();
        }

       
        public IActionResult Brugere()
        {
            return View();
        }
       
        public IActionResult Log()
        {
            return View();
        }
       
        public IActionResult Tider()
        {
            return View();
        }
    }


}
