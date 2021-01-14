using HMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Interface
{
    public interface IRoomManager
    {
        List<Room> GetRoom();
        List<Room> PostRoom(Room model);

        List<Room> GetRoom(int id);
    }
}
