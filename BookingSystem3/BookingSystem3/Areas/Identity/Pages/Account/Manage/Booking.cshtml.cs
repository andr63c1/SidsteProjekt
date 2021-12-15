using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BookingSystem3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingSystem3.Areas.Identity.Pages.Account.Manage
{
    public partial class BookingModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BookingModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Standard price")]
            public float StandardPrice { get; set; }

            [Display(Name = "Max bookings")]
            public int MaxBookings { get; set; }

            [Display(Name = "VAT number")]
            public string VATNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var standardPrice = user.StandardPrice;
            var maxBookings = user.MaxBookings;
            var vatNumber = user.VATNumber;

            Username = userName;

            Input = new InputModel
            {
                StandardPrice = standardPrice,
                MaxBookings = maxBookings,
                VATNumber = vatNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var standardPrice = user.StandardPrice;
            if (Input.StandardPrice != standardPrice)
            {
                user.StandardPrice = Input.StandardPrice;
                await _userManager.UpdateAsync(user);
            }

            var maxBookings = user.MaxBookings;
            if (Input.MaxBookings != maxBookings)
            {
                user.MaxBookings = Input.MaxBookings;
                await _userManager.UpdateAsync(user);
            }

            var vatNumber = user.VATNumber;
            if (Input.VATNumber != vatNumber)
            {
                user.VATNumber = Input.VATNumber;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
