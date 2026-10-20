using DatorsalsBokningen.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DatorsalsBokningen
{
    public class BookingService
    {
        private readonly List<Booking> _bookings = new()
        {
            new Booking
            {
                Id = 1,
                Name = "Ada Lovelace",
                StartTime = DateTime.Today.AddHours(8),
                EndTime = DateTime.Today.AddHours(9),
                Purpose = "Unity"
            },
            new Booking
            {
                Id = 2,
                Name = "Alan Turing",
                StartTime = DateTime.Today.AddHours(0),
                EndTime = DateTime.Today.AddHours(11),
                Purpose = "C#"
            },
            new Booking
            {
                Id = 3,
                Name = "Grace Hopper",
                StartTime = DateTime.Today.AddHours(13),
                EndTime = DateTime.Today.AddHours(15),
                Purpose = "1"
            }
        };

        public List<Booking> GetAllBookings()
        {
            return _bookings
                .OrderByDescending(b => b.StartTime)
                .ToList();
        }

        public Booking CreateBooking(string name, DateTime startTime, DateTime endTime, string purpose)
        {
            if (HasOverlap(startTime, endTime))
            {
                throw new InvalidOperationException("Tiden är redan bokad.");
                
            }
            
            Booking booking = new()
            {
                Id = _bookings.Count + 1,
                Name = name,
                StartTime = startTime,
                EndTime = endTime,
                Purpose = purpose
            };

            _bookings.Add(booking);
            return booking;
        }

        public void CancelBooking(int id)
        {
            Booking booking = _bookings.First(b => b.Id == id);
            _bookings.Remove(booking);
        }

        public void EditBooking(int id, string name, DateTime startTime, DateTime endTime, string purpose)
        {
            Booking booking = _bookings.First(b => b.Id == id);

            if (HasOverlap(startTime, endTime))
                throw new InvalidOperationException("Tiden är redan bokad.");
            else

            booking.Name = name;
            booking.StartTime = startTime;
            booking.EndTime = endTime;
            booking.Purpose = purpose;
        }

        private bool HasOverlap(DateTime startTime, DateTime endTime)
        {
            return _bookings.Any(existing =>
                startTime <= existing.EndTime ||
                endTime >= existing.StartTime);
        }
    }
}