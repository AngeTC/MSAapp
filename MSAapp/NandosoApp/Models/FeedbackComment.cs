using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NandosoApp.Models
{
    public class FeedbackComment
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackCommentID { get; set; }

        public string poster { get; set; }
        public string comment { get; set; }

        [Key, Column(Order = 2)]
        public virtual int FeedbackPostID { get; set; }

        [JsonIgnore]
        public virtual FeedbackPost feedbackPost { get; set; }
    }
}