using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace NandosoApp.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NandosoAppContext : DbContext
    {
        public class MyConfiguration : DbMigrationsConfiguration<NandosoAppContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(NandosoAppContext context)
            {
                //Initialise specials information.
                var specials = new List<Special>
            {
                new Special { specialName = "The 241", specialDesc = "Get two whole chickens for the price of one!",
                    specialPrice = "$25.00" },
                new Special { specialName = "Family Feed", specialDesc = "One whole chicken, with three sides of your choice.",
                    specialPrice = "$40.00" },
                new Special { specialName = "Lunch Special", specialDesc = "One chicken burger, with large fries and a drink of your choice.",
                    specialPrice = "$16.00" }
            };
                specials.ForEach(s => context.Specials.AddOrUpdate(p => p.specialName, s));
                context.SaveChanges();

                //Initialise posts information.
                var feedbackPosts = new List<FeedbackPost>
            {
                new FeedbackPost {topic = "New Menu?"},
                new FeedbackPost {topic = "Prices are getting a bit high."}
            };
                feedbackPosts.ForEach(s => context.FeedbackPosts.AddOrUpdate(p => p.topic, s));
                context.SaveChanges();

                //Initialise comments information.
                var feedbackComments = new List<FeedbackComment>
            {
                new FeedbackComment {
                    FeedbackPostID = feedbackPosts.Single(p => p.topic == "New Menu?" ).FeedbackPostID,
                    poster = "Billy",
                    comment = "I've been seeing new items on the menu. Glad to see some more variety!"
                },
                new FeedbackComment {
                    FeedbackPostID = feedbackPosts.Single(p => p.topic == "New Menu?" ).FeedbackPostID,
                    poster = "Stella C [Employee]",
                    comment = "Why thank you, Billy! We're happy to see that you are satisfied with the new menu!"
                },
                new FeedbackComment {
                    FeedbackPostID = feedbackPosts.Single(p => p.topic == "Prices are getting a bit high." ).FeedbackPostID,
                    poster = "Disgruntled",
                    comment = "I swear, you guys used to be soooo affordable. But these prices are getting outrageous!"
                },
                new FeedbackComment {
                    FeedbackPostID = feedbackPosts.Single(p => p.topic == "Prices are getting a bit high." ).FeedbackPostID,
                    poster = "Dave",
                    comment = "Agreed, but there are worse out there."
                },
                new FeedbackComment {
                    FeedbackPostID = feedbackPosts.Single(p => p.topic == "Prices are getting a bit high." ).FeedbackPostID,
                    poster = "Taylor Day [Employee]",
                    comment = "We're sorry to hear that our prices have not met your standards. Have you seen our recent specials, sir? Perhaps you may be interested in those?"
                },
            };
                feedbackComments.ForEach(s => context.FeedbackComments.AddOrUpdate(p => p.poster, s));
                context.SaveChanges();
            }
    }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public NandosoAppContext() : base("name=NandosoAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoAppContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<NandosoApp.Models.Special> Specials { get; set; }

        public System.Data.Entity.DbSet<NandosoApp.Models.FeedbackComment> FeedbackComments { get; set; }

        public System.Data.Entity.DbSet<NandosoApp.Models.FeedbackPost> FeedbackPosts { get; set; }
    }
}
