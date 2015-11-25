using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NandosoApp.Models
{
    public class FeedbackPost
    {
        public int FeedbackPostID { get; set; }
        public string topic { get; set; }

        public virtual ICollection<FeedbackComment> Comments { get; set; }

        public FeedbackPost()
        {
            Comments = new HashSet<FeedbackComment>();
        }
    }
}