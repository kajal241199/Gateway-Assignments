using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace HMS.BAL
{
    public class HotelManager : IHotelManager
    {
        public List<Hotel> GetHotel()
        {
            //string allText = System.IO.File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json");

            //Hotel HotelList = JsonConvert.DeserializeObject<Hotel>(allText);
            //return HotelList;
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json");
            var hotelList = JsonConvert.DeserializeObject<List<Hotel>>(json);
            return hotelList;
        }

       

        public List<Hotel> PostHotel(Hotel model)
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json");
            var hotelList = JsonConvert.DeserializeObject<List<Hotel>>(json);
            
                Hotel hotel = new Hotel();
                hotel.Id = model.Id;
                hotel.HotelName = model.HotelName;
                hotel.Address = model.Address;
                hotel.City = model.City;
                hotel.PinCode = model.PinCode;
                hotel.Contact = model.Contact;
                hotel.ContactPerson = model.ContactPerson;
                hotel.Website = model.Website;
                hotel.Facebook = model.Facebook;
                hotel.Twitter = model.Twitter;
                hotel.IsActive = model.IsActive;
                hotel.CreatedDate = model.CreatedDate;
                hotel.CreatedBy = model.CreatedBy;
                hotel.UpdatedDate = model.UpdatedDate;
                hotel.UpdatedBy = model.UpdatedBy;

                hotelList.Add(hotel);
                // File.WriteAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json", hotelList.ToString());
                
            
            return hotelList;
        }

        public List<Hotel> SortHotel()
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json");
            var hotelList = JsonConvert.DeserializeObject<List<Hotel>>(json);
            //hotelList.Sort();
            hotelList.OrderByDescending(t => t.HotelName);
            return hotelList;
        }
    }
}
