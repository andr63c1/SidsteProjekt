using BookingSystem3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly BookingContext _context;
        public AdminController(BookingContext context)
        {
            _context = context;
        }
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
            return View(_context.GetUser());
        }
       
        public IActionResult Log()
        {
            return View();
        }
       
        public IActionResult Tider()
        {
            return View(_context.GetTimeSlots());
        }
        public IActionResult AddTid()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTid(TimeSlot timeSlot)
        {
            _context.AddTimeSlot(timeSlot);
            return Redirect("/Admin/Tider"); ;
        }
        [HttpGet("/Admin/EditUser/{id}")]
        public IActionResult EditUser(int id)
        {
            return View(_context.GetUser(id));
        }

        public IActionResult EditBooking()
        {
            return View();
        }
    }


}
