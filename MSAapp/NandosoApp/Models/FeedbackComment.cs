using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NandosoApp.Models
{
    public class FeedbackComment
    {
        public int FeedbackCommentID { get; set; }
        public int FeedbackPostID { get; set; }
        public string poster { get; set; }
        public string comment { get; set; }
    }
}