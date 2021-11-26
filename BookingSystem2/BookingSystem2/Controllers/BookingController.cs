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

        public Booking AddBooking(Booking booking)
        {
            //Add booking to database
            var b = _context.Add(booking).Entity;
            return b;
        }
    }
}
