using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem2.Models;

namespace BookingSystem2.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingContext _context;

        public BookingController(BookingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Booking booking)
        {
                //Add booking to database
                _context.Bookings.Add(booking);
                _context.SaveChanges();

            return Index();
        }
    }
}
