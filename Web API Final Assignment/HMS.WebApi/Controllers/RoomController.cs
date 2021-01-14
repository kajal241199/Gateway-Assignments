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
    public class RoomController : ApiController
    {

        private readonly IRoomManager _roommanager;

        public RoomController(IRoomManager roomManager)
        {
            _roommanager = roomManager;
        }
        // GET: api/Room
        public IHttpActionResult GetRoom()
        {
            var room = _roommanager.GetRoom();
            return Ok(room);
        }

        // GET: api/Room/5
        [Route("api/Hotel/id")]
        public IHttpActionResult Get(int id)
        {
            var room = _roommanager.GetRoom(id);
            return Ok(room);
        }

        // POST: api/Room
        public IHttpActionResult Post([FromBody]Room data)
        {
            var room = _roommanager.PostRoom(data);
            return Ok(room);
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
