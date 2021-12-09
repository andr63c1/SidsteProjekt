using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Models
{
    public class Customer
    {
        public int customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string company { get; set; }
        public int userCredentials { get; set; }
        public float standardPrice { get; set; }
        public string password { get; set; }
        public int maxBookings { get; set; }
    }
}
