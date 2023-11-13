using ASP_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_WebApi.Data
{
    public class ApplicationDBConnection: DbContext
    {
        //next we need to implement a constructor that carry the connection from appsetting.jason to entityfr
        public ApplicationDBConnection(DbContextOptions<ApplicationDBConnection>option) :base(option) //this signify that we want to run some configuration on our system and whatever that happen we want to pass it to the DB class
        {
            
        }

        //In other to create table here we have to create what they call DbSet
        /*
         The DbSet enables the user to perform various operations like add,
        remove, update, etc. on the entity set*/
        public DbSet<Category> Category { get; set; }

        //ModelBuilder - allows configuration to be specified without modifying your entity classes and
        //we can see data as it allow us to ovveride base and build and configure our application
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Onmodelcreating is just a default name giving to us by entfrwrk
        {
            modelBuilder.Entity<Category>().HasData( //now have modeBulder.access to Entity and what modelbuilder(Category)
                                                     //with HasData(whish accept Array as this is use to generate migration) 
            new Category { Id = 1, Name = " Action", DisplayOrders = 1 },
            new Category { Id = 2, Name = " Scifi", DisplayOrders = 2 },
            new Category { Id = 3, Name = " Thriller", DisplayOrders = 3},
            new Category { Id = 4, Name = " History", DisplayOrders = 4 },
            new Category { Id = 5, Name = " Drama", DisplayOrders = 5 });
        }
    }
}
