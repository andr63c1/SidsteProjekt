using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem2.Models
{
    public class Booking
    {
        public int bookingID { get; set; }
        public DateTime paymentDate { get; set; }
        public bool status { get; set; }
        public DateTime date { get; set; }
        public DateTime startTime { get; set; }
        public float duration { get; set; }
        public string topic { get; set; }
        public string comment { get; set; }
    }
}
