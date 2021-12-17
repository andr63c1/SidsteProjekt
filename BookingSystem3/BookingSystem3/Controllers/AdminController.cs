using BookingSystem3.Data;
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
        private readonly ApplicationDbContext _appContext;
        public AdminController(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Bookinger", "Admin");
        }

        public IActionResult Bookinger()
        {
            return View(_appContext.GetBookings());
        }


        public IActionResult Brugere()
        {
            return View(_appContext.GetUsers());
        }

        public IActionResult Log()
        {
            return View();
        }

        public IActionResult Tider()
        {
            return View(_appContext.GetTimeSlots());
        }
        public IActionResult AddTid()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTid(TimeSlot timeSlot)
        {
            _appContext.AddTimeSlot(timeSlot);
            return Redirect("/Admin/Tider"); ;
        }
        [HttpGet("/Admin/EditUser/{id}")]
        public IActionResult EditUser(string id)
        {
            return View(_appContext.GetUser(id));
        }

        [HttpGet("/Admin/EditTimeSlot/{id}")]
        public IActionResult EditTimeSlot(int id)
        {
            return View(_appContext.GetTimeSlot(id));
        }

        [HttpPost]
        public IActionResult EditTimeSlot(TimeSlot timeSlot)
        {
            _appContext.EditTimeSlot(timeSlot);
            return Redirect("/Admin/Tider");
        }

        [HttpPost]
        public IActionResult EditUser(ApplicationUser user)
        {
            _appContext.EditUser(user);
            return Redirect("/Admin/Brugere");
        }

        [HttpGet("/Admin/EditBooking/{id}")]
        public IActionResult EditBooking(int id)
        {
            return View(_appContext.GetBooking(id));
        }

        [HttpPost]
        public IActionResult EditBooking(Booking booking)
        {
            _appContext.EditBooking(booking);
            return Redirect("/Admin/Bookinger");
        }

        [HttpGet("/Admin/DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _appContext.DeleteBooking(_appContext.GetBooking(id));
            return Redirect("/Admin/Bookinger");
        }

        [HttpGet("/Admin/DeleteUser/{id}")]
        public IActionResult DeleteUser(string id)
        {
            _appContext.DeleteUser(_appContext.GetUser(id));
            return Redirect("/Admin/Brugere");
        }

        [HttpGet("/Admin/DeleteTimeSlot/{id}")]
        public IActionResult DeleteTimeSlot(int id)
        {
            _appContext.DeleteTimeSlot(_appContext.GetTimeSlot(id));
            return Redirect("/Admin/Tider");
        }
    }


}
