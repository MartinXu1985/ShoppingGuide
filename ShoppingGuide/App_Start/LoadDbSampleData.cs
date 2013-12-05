using System.Web;
using System.Web.Optimization;
using ShoppingGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.IO;

namespace ShoppingGuide
{
    public class LoadDbSampleData
    {
        public static void loadData()
        {
            // Drop the database first..
            System.Data.Entity.Database.SetInitializer
                (new DropCreateDatabaseAlways<ShoppingGuideDB>());

            ShoppingGuideDB db = new ShoppingGuideDB();

           new List<Product>
           {
               
               new Product { CategoryId = 0, 
                             Name = "Computer Desk", 
                             Price = 59, 
                             ProductUrl ="/content/", 
                             Description = "This desk is the perfect answer to organizing clutter in your child’s room. It features a compact design yet includes space for everything needed for schoolwork and projects. A low hutch offers shelving for books or keepsakes, and the spacious desktop offers plenty of room to spread out homework or house a laptop. Underneath the desktop, a shelf keeps a computer keyboard ready for use until it’s needed. Flexible storage options include a drawer and 2 open shelves that offer room for a CPU, writing supplies and paper. Partially open back for wire management. This desk has been designed to perfectly match any South Shore Furniture’s item in Black finish. Made of recycled CARB compliant particle pannels, this bookcase has to be assembled by two adults. Measures 42 inches wide by 20 inches deep by 36.75 inches high. It is delivered in one box measuring 44 inches by 22 inches by 7 inches and weighs 85 pounds. Tools are not included. 5 year warranty. Made in Mexico. Manufacturer style number: 7270076", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/desk.jpg",
                             Rating = 4,
                             Votes = 234},
                 new Product { CategoryId = 0, 
                             Name = "Cushion Chair", 
                             Price = 40, 
                             ProductUrl ="/content/", 
                             Description = "Beautiful gingham fabric easy to coordinate,Strong wooden frame, for durability ,High Density flame retardant foam, for added comfort, Wooden legs, for a realfurniture look, Available in assorted colors", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/chair.jpg",
                             Rating = 4,
                             Votes = 298},
                 new Product { CategoryId = 0, 
                             Name = "Cutlery Set", 
                             Price = 77, 
                             ProductUrl ="/content/", 
                             Description = "High carbon stainless steel creates a stronger harder blade resisting stains rust and pitting, Lack nonslip cushion grip handles allow for a sturdy grip on all knives, Stainless steel plates at the end of the handle convey sleek and contemporary styling", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/cutlery.jpg",
                             Rating = 5,
                             Votes = 666},
                 new Product { CategoryId = 0, 
                             Name = "Vacuum Cleaner", 
                             Price = 199, 
                             ProductUrl ="/content/", 
                             Description = "Lightweight upright vacuum cleaner with WindTunnel Technology for consistent suction, Five position height adjustment; 13-1/2-inch-wide nozzle; no-scuff bumper, 27-foot retractable power cord; rinse-clean filter and permanent HEPA filter", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/vacuum.jpg",
                             Rating = 5,
                             Votes = 777},
                 new Product { CategoryId = 0, 
                             Name = "Trash Can", 
                             Price = 19, 
                             ProductUrl ="/content/", 
                             Description = "Perfect for small spaces: fits well in bathrooms, under desks, or wherever space is limited.Strong steel pedal: engineered for a smooth and easy step.Fingerprint-proof: fingerprint-proof finish resists smudges to keep stainless steel shiny.Classic round shape: the classic round shape fits well just about anywhere",
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/trash.jpg",
                             Rating = 3,
                             Votes = 177},
               new Product { CategoryId = 1, 
                             Name = "Spalding BasketBall", 
                             Price = 19, 
                             ProductUrl ="/content/", 
                             Description = "Want a basketball made for pick-up games at the park or in the driveway? If so, grab Spalding's NBA Street Basketball. This ball is made with a durable rubber cover so it holds up over a long period of time, no matter how rough the surface. This ball's deep channels and pebbled outer covering give you superior grip and handling along with a consistent and reliable bounce.Performance rubber coverDeep channel design for improved grip - great for shootersOfficial NBA size and weightDesigned for outdoor playImportedThere are core sizes for basketballs: Size 5, Size 6 and Size 7. The size you require depends on the age of the player concerned and also the sex of the player. A size 5 basketball, is designed for players up to age 9. The ball has a circumference of 27.75 and weighs approximately 18oz. A size 6 basketball, is designed for players between the ages of 9 to 12. This is also the ball specified for Women. The ball has a circumference of 28.5 and weighs approximately 20oz. A size 7 basketball, is designed for all male players, 13 years and above. The ball has a circumference of 29.5 and weighs 22oz.", 
                             CategoryName = "Sports",
                             Image = "~/Content/Uploads/ball.jpg",
                             Rating = 3,
                             Votes = 150},
               new Product { CategoryId = 2, 
                             Name = "Programming for the Absolute Beginner", 
                             Price = 29, 
                             ProductUrl ="/content/", 
                             Description = "Want to learn computer programming but aren't sure where to start? Programming for the Absolute Beginner provides a gentle learning curve in programming for anyone who wants to develop fundamental programming skills and create computer programs. The primary focus is on teaching the reader how to program using a free implementation of BASIC called Just BASIC. As such, the book focuses on developing programs that run on Microsoft Windows, but also presents programming principles that apply to different environments, including other operating systems and the Internet. Additionally, the book provides a solid foundation for advancing to different programming languages as you gain confidence in your newly acquired programming abilities. As part of the for the absolute beginner series, Programming for the Absolute Beginner teaches all the concepts through the creation of simple computer games, making the learning process much more fun and enjoyable.", 
                             CategoryName = "Books",
                             Image = "~/Content/Uploads/textbook.jpg",
                             Rating = 5,
                             Votes = 1},
               new Product { CategoryId = 3, 
                             Name = "T-Shirt", 
                             Price = 9, 
                             ProductUrl ="/content/", 
                             Description = "Casual enough for day and breezy enough to take you through the seasons, this button-down is the one to rock in every color. Throw it on over a tee for instant daytime cool. Woven textured shirt. Pointed collar. Long sleeves with single-barrel cuffs. Tabbed detail at shoulders. Patch pockets at chest. Double-layered detail at collar and pockets. Front button closures 100% cotton Machine wash.", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/shirt.jpg",
                             Rating = 2,
                             Votes = 4},
               new Product { CategoryId = 4, 
                             Name = "MacBook Pro 15-inch", 
                             Price = 599, 
                             ProductUrl ="/content/", 
                             Description = "A groundbreaking Retina display. All-flash architecture. The latest Intel processors. Remarkably thin and light 13-inch and 15-inch designs. Together, these features take the notebook to a place it's never been. And they'll do the same for everything you create with it. The 15-inch MacBook Pro with Retina display has the power to do even more amazing things. Fourth-generation quad-core Intel Core i7 processors provide the fastest performance ever in a MacBook Pro.", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/computer.jpg",
                             Rating = 0,
                             Votes = 0},
           }.ForEach(a => db.Product.Add(a));

            db.SaveChanges();
        }
    }
}
