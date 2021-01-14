using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    public class Booking
    {
      
        public  DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public string StatusOfBooking { get; set; }
        public string HotelName { get; set; }

    }
}
