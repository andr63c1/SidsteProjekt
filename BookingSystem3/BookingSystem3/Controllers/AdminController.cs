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
            return View(_context.GetBookings());
        }


        public IActionResult Brugere()
        {
            return View(_context.GetUsers());
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

        [HttpGet("/Admin/EditTimeSlot/{id}")]
        public IActionResult EditTimeSlot(int id)
        {
            return View(_context.GetTimeSlot(id));
        }

        [HttpPost]
        public IActionResult EditTimeSlot(TimeSlot timeSlot)
        {
            _context.EditTimeSlot(timeSlot);
            return Redirect("/Admin/Tider");
        }

        [HttpPost]
        public IActionResult EditUser(Customer customer)
        {
            _context.EditUser(customer);
            return Redirect("/Admin/Brugere");
        }

        [HttpGet("/Admin/EditBooking/{id}")]
        public IActionResult EditBooking(int id)
        {
            return View(_context.GetBooking(id));
        }

        [HttpPost]
        public IActionResult EditBooking(Booking booking)
        {
            _context.EditBooking(booking);
            return Redirect("/Admin/Bookinger");
        }

        [HttpGet("/Admin/DeleteBooking/{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _context.DeleteBooking(_context.GetBooking(id));
            return Redirect("/Admin/Bookinger");
        }

        [HttpGet("/Admin/DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _context.DeleteUser(_context.GetUser(id));
            return Redirect("/Admin/Brugere");
        }

        [HttpGet("/Admin/DeleteTimeSlot/{id}")]
        public IActionResult DeleteTimeSlot(int id)
        {
            _context.DeleteTimeSlot(_context.GetTimeSlot(id));
            return Redirect("/Admin/Tider");
        }
    }


}
