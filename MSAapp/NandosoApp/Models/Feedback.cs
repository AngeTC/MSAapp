using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NandosoApp.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string feedbackContent { get; set; }
    }
}