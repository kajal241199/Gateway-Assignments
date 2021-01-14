
using HMS.BAL.Interface;
using HMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HMS.BAL
{
    public class RoomManager : IRoomManager
    {
        public List<Room> GetRoom()
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Room.json");
            var roomList = JsonConvert.DeserializeObject<List<Room>>(json);
            return roomList;

        }

        public List<Room> GetRoom(int Id)
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Room.json");
            var roomList = JsonConvert.DeserializeObject<List<Room>>(json);
            /*var find = roomList.Find();
            Room room = new Room();
            room.Id = find.Id;
            room.RoomName = find.RoomName;
            room.RoomCategory = find.RoomCategory;
            room.Price = find.Price;
            room.IsActive = find.IsActive;
            room.CreatedDate = find.CreatedDate;
            room.CreatedBy = find.CreatedBy;
            room.UpdatedDate = find.UpdatedDate; 
            room.UpdatedBy = find.UpdatedBy;
            room.HotelName = find.HotelName; */
            return roomList;

        }

        public List<Room> PostRoom(Room model)
        {
            string json = File.ReadAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Room.json");
            var roomList = JsonConvert.DeserializeObject<List<Room>>(json);
            Room room = new Room();
            room.Id = model.Id;
            room.RoomName = model.RoomName;
            room.RoomCategory = model.RoomCategory;
            room.Price = model.Price;
            room.IsActive = model.IsActive;
            room.CreatedDate = model.CreatedDate;
            room.CreatedBy = model.CreatedBy;
            room.UpdatedDate = model.UpdatedDate;
            room.UpdatedBy = model.UpdatedBy;
            room.HotelName = model.HotelName;

            roomList.Add(room);
            // File.WriteAllText(@"C:\Users\Kajal\source\repos\HMS.WebApi/Hotel.json", hotelList.ToString());
            return roomList;
        }
    }
}
