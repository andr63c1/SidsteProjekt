using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem2.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int userCredentials { get; set; }
        public string password { get; set; }
    }
}
