using HMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HMS.BAL.Interface
{
     public class BookingManager : IBookingManager
    {
        public void DeleteBooking(int id, string HotelName, DateTime bookingDate)
        {
            bool status = false;
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Booking.json");
            var bookingList = JsonConvert.DeserializeObject<List<Booking>>(json);
            foreach (var i in bookingList)
            {
                if(i.HotelName == HotelName && i.RoomId==id && i.BookingDate == bookingDate)
                {
                    if(i.StatusOfBooking == "Definitive")
                    {
                        bookingList.Remove(i);
                        Console.WriteLine("Deleted Successfully!" );
                        status = true;
                    }
                }
                

            }
            if(!status)
            {
                Console.WriteLine("Not Found");
            }
           
























































































        }

        public List<Booking> PostBooking(Booking model)
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Booking.json");
            var bookingList = JsonConvert.DeserializeObject<List<Booking>>(json);
            Booking booking = new Booking();
            booking.BookingDate= model.BookingDate;
            booking.RoomId = model.RoomId;
            booking.StatusOfBooking = model.StatusOfBooking;
            booking.HotelName = model.HotelName;
            bookingList.Add(booking);
            return bookingList;
        }
    }
}
