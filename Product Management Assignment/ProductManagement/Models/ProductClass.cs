using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class ProductClass
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
      
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }

        public string Small_Image { get; set; }

        public string Large_Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}