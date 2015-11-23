using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MSAapp.Models
{
    public class MSAappContext : DbContext
    {
        public class MyConfiguration : DbMigrationsConfiguration<MSAappContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(MSAappContext context)
            {
                var specials = new List<Special>
            {
                new Special { specialName = "The 241", specialDescription = "Get two whole chickens for the price of one!",
                    specialPrice = "$25.00", expiryDate = DateTime.Parse("2015-12-10") },
                new Special { specialName = "Family Feed", specialDescription = "One whole chicken, with three sides of your choice.",
                    specialPrice = "$40.00", expiryDate = DateTime.Parse("2015-12-20") },
                new Special { specialName = "Lunch Special", specialDescription = "One chicken burger, with large fries and a drink of your choice.",
                    specialPrice = "$18.00", expiryDate = DateTime.Parse("2015-12-30") },
            };
                specials.ForEach(s => context.Specials.AddOrUpdate(p => p.specialName, s));
                context.SaveChanges();

                var feedbacks = new List<Feedback>
            {
                new Feedback {email = "b.herald@gmail.com", feedbackContent = "Loving the new menu!"},
            };
                feedbacks.ForEach(s => context.Feedbacks.AddOrUpdate(p => p.email, s));
                context.SaveChanges();
            }
        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MSAappContext() : base("name=MSAappContext")
        {
        }

        public System.Data.Entity.DbSet<MSAapp.Models.Special> Specials { get; set; }

        public System.Data.Entity.DbSet<MSAapp.Models.Feedback> Feedbacks { get; set; }
    }
}
