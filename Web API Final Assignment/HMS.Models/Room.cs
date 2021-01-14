using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomCategory { get; set; }
        public float Price { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public string HotelName { get; set; }


    }
    public class Root1
    {
        public List<Room> Rooms { get; set; }
    }
}
