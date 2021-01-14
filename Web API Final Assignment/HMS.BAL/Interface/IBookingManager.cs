using HMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Interface
{
    public interface IBookingManager
    {
        List<Booking> PostBooking(Booking model);

       void DeleteBooking(int id,string HotelName, DateTime bookingDate);
    }
}
