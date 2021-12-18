using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Models
{
    public class BookingPageViewModel
    {
        public BookingVM Booking { get; set; }
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
