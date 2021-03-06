using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem3.Models
{
    public class BookingContext : DbContext
    {
        private readonly ILogger<BookingContext> _logger;

        public BookingContext(DbContextOptions<BookingContext> options, ILogger<BookingContext> logger) : base(options)
        {
            _logger = logger;
            Database.EnsureCreated();
        }

        private DbSet<Booking> Bookings { get; set; }
        private DbSet<TimeSlot> TimeSlots { get; set; }

        public Booking AddBooking(Booking booking)
        {
            Booking _booking = Bookings.Add(booking).Entity;
            SaveChanges();
            _logger.Log(LogLevel.Information, "Booking Added with Id:" + _booking.bookingID.ToString());
            return _booking;
        }

        public TimeSlot AddTimeSlot(TimeSlot timeSlot)
        {
            TimeSlot _timeSlot = TimeSlots.Add(timeSlot).Entity;
            SaveChanges();
            _logger.Log(LogLevel.Information, "TimeSlot Added with Id:" + _timeSlot.timeSlotID.ToString());
            return _timeSlot;
        }

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            return TimeSlots;
        }

        public Customer EditUser(Customer user)
        {
            this.Update(user);
            SaveChanges();

            return user;
        }

        public TimeSlot GetTimeSlot(int id)
        {
            return TimeSlots.Single(x => x.timeSlotID == id);
        }

        public TimeSlot EditTimeSlot(TimeSlot timeSlot)
        {
            this.Update(timeSlot);
            SaveChanges();

            return timeSlot;
        }

        public IEnumerable<Booking> GetBookings()
        {
            return Bookings;
        }
        
        public Booking GetBooking(int id)
        {
            return Bookings.Single(x => x.bookingID == id);
        }

        public Booking EditBooking(Booking booking)
        {
            this.Update(booking);
            SaveChanges();

            return booking;
        }

        public Booking DeleteBooking(Booking booking)
        {
            this.Remove(booking);
            SaveChanges();

            return booking;
        }

        public Customer DeleteUser(Customer user)
        {
            this.Remove(user);
            SaveChanges();

            return user;
        }

        public TimeSlot DeleteTimeSlot(TimeSlot timeSlot)
        {
            this.Remove(timeSlot);
            SaveChanges();

            return timeSlot;
        }
    }
}
