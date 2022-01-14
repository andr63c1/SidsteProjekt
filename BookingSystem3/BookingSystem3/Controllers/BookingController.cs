using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem3.Models;
using BookingSystem3.Services;
using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BookingSystem3.Data;

namespace BookingSystem3.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IBraintreeService _braintreeService;
        public BookingController( ApplicationDbContext context, IBraintreeService braintreeService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _braintreeService = braintreeService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            BookingPageViewModel model = new BookingPageViewModel();
            model.TimeSlots = _context.GetTimeSlots();
            model.Booking = new BookingVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BookingVM booking)
        {
            booking.creater = _userManager.GetUserAsync(User).Result;

            if(_context.GetTimeSlotForBooking(booking) != null)
            {
                booking.timeSlot = _context.GetTimeSlotForBooking(booking);
            }
            else { return Redirect("/Booking/Failure"); }
            
            //Add booking to database
            var newBooking =_context.AddBooking(booking);

            var userRoles = _userManager.GetRolesAsync(booking.creater).Result;
            foreach(string str in userRoles)
            {
                if (str == "Verified")
                {
                    return Succes(booking);
                }
            }
            
            return Redirect("/Booking/Checkout/" + newBooking.bookingID);
        }

        public IActionResult Checkout(int Id)
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();  //Genarate a token
            ViewBag.ClientToken = clientToken;

            BookingVM data = BookingVM.ConvertBookingToVM(_context.GetBooking(Id));

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(BookingVM model)
        {
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(model.GetTotalPrice()),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return Succes(model);
            }
            else
            {
                return Failure(model);
            }
        }

        public IActionResult Succes(BookingVM model)
        {
            return View("Succes", model);
        }

        public IActionResult Failure(BookingVM model)
        {
            return View("Failure", model);
        }
    }
}
