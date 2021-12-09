using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Models
{
    public class TimeSlot
    {
        public int timeSlotID { get; set; }
        public DateTime date { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public float standardPrice { get; set; }
        public float specialPrice { get; set; }
    }
}
