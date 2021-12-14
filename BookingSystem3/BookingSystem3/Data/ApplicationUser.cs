using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Company { get; set; }
        public string Phone { get; set; }
    }
}
