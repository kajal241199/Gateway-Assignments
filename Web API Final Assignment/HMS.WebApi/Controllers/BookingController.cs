using HMS.BAL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingmanager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingmanager = bookingManager;
        }

        // GET: api/Booking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]Booking data)
        {
            var booking = _bookingmanager.PostBooking(data);
            return Ok(booking);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        { 
        }

        // DELETE: api/Booking/5
        public void Delete(int id, string HotelName, DateTime bookingDate)
        {
            _bookingmanager.DeleteBooking(id,HotelName,bookingDate);
            
            
        }
    }
}
