using BookingSystem3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingSystem3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger)
            : base(options)
        {
            _logger = logger;
            Database.EnsureCreated();
        }

        private DbSet<Booking> Bookings { get; set; }
        private DbSet<TimeSlot> TimeSlots { get; set; }

        public ApplicationUser GetUser(string id)
        {
            return Users.Single(x => x.Id == id);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return Users;
        }

        public ApplicationUser EditUser(ApplicationUser model)
        {
            var user = Users.FirstOrDefault(u => u.Id == model.Id);

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.VATNumber = model.VATNumber;
            user.MaxBookings = model.MaxBookings;
            user.StandardPrice = model.StandardPrice;
            user.Company = model.Company;


            Users.Update(user);
            SaveChanges();

            return user;
        }

        public ApplicationUser DeleteUser(ApplicationUser user)
        {
            this.Remove(user);
            SaveChanges();

            return user;
        }

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
            List<Booking> bookingList = new List<Booking>();
            foreach(Booking booking in Bookings)
            {
                bookingList.Add(GetBooking(booking.bookingID));
            }

            return bookingList;
        }

        public Booking GetBooking(int id)
        {
            Booking booking = Bookings.Include(x => x.timeSlot).Include(x => x.creater).Single(x => x.bookingID == id);
            booking.timeSlot = TimeSlots.Include(x => x.creater).Single(x => x.timeSlotID == booking.timeSlot.timeSlotID);
            return booking;
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

        public TimeSlot DeleteTimeSlot(TimeSlot timeSlot)
        {
            this.Remove(timeSlot);
            SaveChanges();

            return timeSlot;
        }
    }
}
