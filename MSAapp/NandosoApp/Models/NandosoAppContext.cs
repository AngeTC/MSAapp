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
                var specials = new List<Special>
            {
                new Special { specialName = "The 241", specialDesc = "Get two whole chickens for the price of one!",
                    specialPrice = "$25.00" },
                new Special { specialName = "Family Feed", specialDesc = "One whole chicken, with three sides of your choice.",
                    specialPrice = "$40.00" },
                new Special { specialName = "Lunch Special", specialDesc = "One chicken burger, with large fries and a drink of your choice.",
                    specialPrice = "$18.00" }
            };
                specials.ForEach(s => context.Specials.AddOrUpdate(p => p.specialName, s));
                context.SaveChanges();

                var feedbacks = new List<Feedback>
            {
                new Feedback {email = "b.herald@gmail.com", feedbackContent = "Loving the new menu!"}
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

        public NandosoAppContext() : base("name=NandosoAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoAppContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<NandosoApp.Models.Special> Specials { get; set; }

        public System.Data.Entity.DbSet<NandosoApp.Models.Feedback> Feedbacks { get; set; }
    }
}
