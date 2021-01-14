using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Models
{
    
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public  int PinCode { get; set; }
        public string Contact { get; set; }

        public string ContactPerson { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        public  bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }


    }
    public class Root
    {
        public List<Hotel> Hotels { get; set; }
    }

}
