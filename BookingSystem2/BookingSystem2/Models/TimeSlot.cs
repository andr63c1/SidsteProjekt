using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem2.Models
{
    public class TimeSlot
    {
        public int timeSlotId { get; set; }
        public DateTime date { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public float stanmdardPrice { get; set; }
        public float specialPrice { get; set; }
    }
}
