using ASP_.Net_MVC_PROJECT.Models;
using Microsoft.EntityFrameworkCore;



namespace ASP_.Net_MVC_PROJECT.DATAACCESS.Data
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
        public DbSet<Product> Products { get; set; }

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

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "Fortune of Time",
                   Author = "Billy Spark",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "SWD9999001",
                   ListPrice = 99,
                   Price = 90,
                   Price50 = 85,
                   Price100 = 80,
                   CategoryId = 1,
                   ImageUrl =""
               },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                });

               
        }
    }
}
