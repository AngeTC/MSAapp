using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSAapp.Models
{
    public class Special
    {
        public int id { get; set; }
        public string specialName { get; set; }
        public string specialDescription { get; set; }
        public string specialPrice { get; set; }
        public DateTime expiryDate { get; set; }
    }
}