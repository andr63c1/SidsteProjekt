using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Phone { get; set; }
        public string Company { get; set; }
        public float StandardPrice { get; set; }
        public int MaxBookings { get; set; }
        public string VATNumber { get; set; }
    }
}
