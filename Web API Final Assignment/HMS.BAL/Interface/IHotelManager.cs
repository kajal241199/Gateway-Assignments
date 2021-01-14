using HMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.BAL.Interface
{
    public interface IHotelManager
    {


        List<Hotel> GetHotel();
        List<Hotel> PostHotel(Hotel model);

        List<Hotel> SortHotel();
        

    }
}
