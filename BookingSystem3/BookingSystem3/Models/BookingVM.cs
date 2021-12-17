using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Models
{
    public class BookingVM : Booking
    {

        public static BookingVM ConvertBookingToVM(Booking input)
        {
            BookingVM booking = new BookingVM();
            booking.bookingID = input.bookingID;
            booking.paymentDate = input.paymentDate;
            booking.status = input.status;
            booking.startTime = input.startTime;
            booking.duration = input.duration;
            booking.topic = input.topic;
            booking.comment = input.comment;
            booking.timeSlot = input.timeSlot;
            booking.creater = input.creater;
            return booking;
        }
        public string Nonce { get; set; }
    }
}
