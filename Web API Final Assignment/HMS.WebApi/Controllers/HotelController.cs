using HMS.BAL;
using HMS.BAL.Interface;
using HMS.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace HMS.WebApi.Controllers
{
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelmanager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelmanager = hotelManager;
        }

        // GET: api/Hotel
        public IHttpActionResult GetHotel()
        {


            /*string allText = System.IO.File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json");
            Hotel[] jsonObject = (Hotel[])JsonConvert.DeserializeObject(allText);

            return Ok(jsonObject);*/
            var hotel = _hotelmanager.GetHotel();
            return Ok(hotel);
            //return (IHttpActionResult)_hotelmanager.GetHotel();




        }

        [HttpGet]
        [Route("api/Hotel/SortHotel")]
        public IHttpActionResult SortHotel()
        {
            var hotel = _hotelmanager.SortHotel();
            return Ok(hotel);
        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hotel
        public IHttpActionResult Post([FromBody]Hotel data)
        {
            var hotel = _hotelmanager.PostHotel(data);
            return Ok(hotel);
            
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
