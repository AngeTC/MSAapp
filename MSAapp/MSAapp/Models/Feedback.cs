using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSAapp.Models
{
    public class Feedback
    {
        public int id { get; set; }
        public string email { get; set; }
        public string feedbackContent { get; set; }
    }
}