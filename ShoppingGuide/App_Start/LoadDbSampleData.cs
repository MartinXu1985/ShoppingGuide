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
               
               new Product {
                             Name = "Computer Desk", 
                             Price = 59, 
                             Description = "This desk is the perfect answer to organizing clutter in your child’s room. It features a compact design yet includes space for everything needed for schoolwork and projects. A low hutch offers shelving for books or keepsakes, and the spacious desktop offers plenty of room to spread out homework or house a laptop. Underneath the desktop, a shelf keeps a computer keyboard ready for use until it’s needed. Flexible storage options include a drawer and 2 open shelves that offer room for a CPU, writing supplies and paper. Partially open back for wire management. This desk has been designed to perfectly match any South Shore Furniture’s item in Black finish. Made of recycled CARB compliant particle pannels, this bookcase has to be assembled by two adults. Measures 42 inches wide by 20 inches deep by 36.75 inches high. It is delivered in one box measuring 44 inches by 22 inches by 7 inches and weighs 85 pounds. Tools are not included. 5 year warranty. Made in Mexico. Manufacturer style number: 7270076", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/desk.jpg",
                             Rating = 4,
                             Votes = 234},
                 new Product {
                             Name = "Cushion Chair", 
                             Price = 40, 
                             Description = "Beautiful gingham fabric easy to coordinate,Strong wooden frame, for durability ,High Density flame retardant foam, for added comfort, Wooden legs, for a realfurniture look, Available in assorted colors", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/chair.jpg",
                             Rating = 4,
                             Votes = 298},
                 new Product {
                             Name = "Cutlery Set", 
                             Price = 77, 
                             Description = "High carbon stainless steel creates a stronger harder blade resisting stains rust and pitting, Lack nonslip cushion grip handles allow for a sturdy grip on all knives, Stainless steel plates at the end of the handle convey sleek and contemporary styling", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/cutlery.jpg",
                             Rating = 5,
                             Votes = 666},
                 new Product {
                             Name = "Vacuum Cleaner", 
                             Price = 199, 
                             Description = "Lightweight upright vacuum cleaner with WindTunnel Technology for consistent suction, Five position height adjustment; 13-1/2-inch-wide nozzle; no-scuff bumper, 27-foot retractable power cord; rinse-clean filter and permanent HEPA filter", 
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/vacuum.jpg",
                             Rating = 5,
                             Votes = 777},
                 new Product {
                             Name = "Trash Can", 
                             Price = 19, 
                             Description = "Perfect for small spaces: fits well in bathrooms, under desks, or wherever space is limited.Strong steel pedal: engineered for a smooth and easy step.Fingerprint-proof: fingerprint-proof finish resists smudges to keep stainless steel shiny.Classic round shape: the classic round shape fits well just about anywhere",
                             CategoryName = "Home",
                             Image = "~/Content/Uploads/trash.jpg",
                             Rating = 3,
                             Votes = 177},
               new Product {
                             Name = "Spalding BasketBall", 
                             Price = 19, 
                             Description = "Want a basketball made for pick-up games at the park or in the driveway? If so, grab Spalding's NBA Street Basketball. This ball is made with a durable rubber cover so it holds up over a long period of time, no matter how rough the surface. This ball's deep channels and pebbled outer covering give you superior grip and handling along with a consistent and reliable bounce.Performance rubber coverDeep channel design for improved grip - great for shootersOfficial NBA size and weightDesigned for outdoor playImportedThere are core sizes for basketballs: Size 5, Size 6 and Size 7. The size you require depends on the age of the player concerned and also the sex of the player. A size 5 basketball, is designed for players up to age 9. The ball has a circumference of 27.75 and weighs approximately 18oz. A size 6 basketball, is designed for players between the ages of 9 to 12. This is also the ball specified for Women. The ball has a circumference of 28.5 and weighs approximately 20oz. A size 7 basketball, is designed for all male players, 13 years and above. The ball has a circumference of 29.5 and weighs 22oz.", 
                             CategoryName = "Sports",
                             Image = "~/Content/Uploads/ball.jpg",
                             Rating = 3,
                             Votes = 150},
               new Product {
                             Name = "Programming for the Absolute Beginner", 
                             Price = 29, 
                             Description = "Want to learn computer programming but aren't sure where to start? Programming for the Absolute Beginner provides a gentle learning curve in programming for anyone who wants to develop fundamental programming skills and create computer programs. The primary focus is on teaching the reader how to program using a free implementation of BASIC called Just BASIC. As such, the book focuses on developing programs that run on Microsoft Windows, but also presents programming principles that apply to different environments, including other operating systems and the Internet. Additionally, the book provides a solid foundation for advancing to different programming languages as you gain confidence in your newly acquired programming abilities. As part of the for the absolute beginner series, Programming for the Absolute Beginner teaches all the concepts through the creation of simple computer games, making the learning process much more fun and enjoyable.", 
                             CategoryName = "Books",
                             Image = "~/Content/Uploads/textbook.jpg",
                             Rating = 5,
                             Votes = 1},
               new Product {
                             Name = "T-Shirt", 
                             Price = 9, 
                             Description = "Casual enough for day and breezy enough to take you through the seasons, this button-down is the one to rock in every color. Throw it on over a tee for instant daytime cool. Woven textured shirt. Pointed collar. Long sleeves with single-barrel cuffs. Tabbed detail at shoulders. Patch pockets at chest. Double-layered detail at collar and pockets. Front button closures 100% cotton Machine wash.", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/shirt.jpg",
                             Rating = 4,
                             Votes = 3},
                new Product {
                             Name = "Sweater", 
                             Price = 69, 
                             Description = "Warm, all season sweater which gives you a cozy feel yet looks elegant for your formal as well as casual wear.Wear it to beleive it!!", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/sweater.jpg",
                             Rating = 2,
                             Votes = 5},
                new Product {
                             Name = "Trousers", 
                             Price = 69, 
                             Description = "Confortable trousers for your every day wear. Must have pair of trouser in your wardrobe. Fit both with you casual as well as formal needs. Available in all sizes.", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/trouser.jpg",
                             Rating = 4,
                             Votes = 3},
                new Product {
                             Name = "Abercrombie Lower", 
                             Price = 65, 
                             Description = "Abercrombie's signature collection bring you varities of lower to choose from. This lower gives you comfort as well as a smart look which you can wear for a walk as well as for your night wear", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/Lower.jpg",
                             Rating = 2,
                             Votes = 2},
                new Product {
                             Name = "Jacket", 
                             Price = 210, 
                             Description = " Full sleeves, furry hood and slim fit jacket for all the handsome guys out there.This is would mkae you look smart yet protect you from cold brreze. Machine wash, dry and easy to handle. A must have piece at a very low price.!!", 
                             CategoryName = "Clothes",
                             Image = "~/Content/Uploads/Jacket.jpg",
                             Rating = 5,
                             Votes = 5},
                new Product {
                             Name = "Google Chromecast", 
                             Price = 35, 
                             Description = " With Chromecast, you can easily enjoy your favorite online entertainment on your HDTV—movies, TV shows, music, and more from Netflix, YouTube, HBO GO, Hulu Plus, Google Play Movies and Music, and Chrome. No more huddling around small screens and tiny speakers. Chromecast automatically updates to work with a growing number of apps.", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/Google Chromecast Digital HD Media Streamer.jpg",
                             Rating = 5,
                             Votes = 5},
               new Product {
                             Name = "iPad Air", 
                             Price = 659, 
                             Description = " You have to hold iPad Air to believe it. It’s just 7.5 millimeters thin and weighs just one pound. The stunning Retina display sits inside thinner bezels, so all you see is your content. And an incredible amount of power lies inside the sleek enclosure. So you can do so much more. With so much less.", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/iPad-Air.jpg",
                             Rating = 5,
                             Votes = 5},
                new Product {
                             Name = "iPhone 5s", 
                             Price = 799, 
                             Description = " Explore high-quality efficiency and a wide range of applications with the sleek and stylish iPhone 5s. This Apple mobile phone features 4-inch multi-touch widescreen IPS Retina display, which supports 1136x640-pixel native resolution at 326 ppi. Powered by a 64-bit Apple A7 processor and an M7 motion coprocessor, this Apple smartphone makes multitasking a breeze and lets you spare your battery power. The iPhone 5s is fully supported by the iOS 7, which makes your day more enjoyable, with its great features. Moreover, the 8 MP rear iSight camera on this Apple mobile phone lets you capture beautiful photos and supports Full HD (1080p) video recording. The iPhone 5s comes in three metallic colors and three capacity options. What’s more, this smartphone supports 802.11n Wi-Fi, Bluetooth 4.0, and 4G/LTE, which ease your sharing and surfing experience.", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/iPhone 5s.jpg",
                             Rating = 5,
                             Votes = 5},
                new Product {
                             Name = "Kodak Easyshare Camera", 
                             Price = 100, 
                             Description = " Capture those special moments with great clarity and bright colors with the 14 megapixel resolutions of the Kodak EASYSHARE C1530 camera. Click and view your picture on the 3.0-inch, 230K color LCD screen of this Kodak 14MP camera. With internal memory of 32MB and SD/SDHC card expansion slot, this Kodak digital camera can save your treasured pictures. The PictBridge compatibility lets you easily transfer files from this Kodak 14MP camera. With shutter speed of 1/4-1/1400 sec, this Kodak digital camera adds a dramatic touch to your pictures, especially while capturing moving objects. The Kodak EASYSHARE C1530 camera can easily capture portrait, landscape, close-up, night portrait candlelight, sunset, sport, and much more.", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/Kodak EASYSHARE C195 14.0 MP Digital Camera.jpg",
                             Rating = 5,
                             Votes = 5},
                new Product {
                             Name = "Playstation 4", 
                             Price = 399, 
                             Description = " The PlayStation®4 system opens the door to an incredible journey through immersive new gaming worlds and a deeply connected gaming community. PS4™ puts gamers first with an astounding launch lineup and over 180 games in development. Play amazing top-tier blockbusters and innovative indie hits on PS4™. Developer Inspired, Gamer Focus. ", 
                             CategoryName = "Electronics",
                             Image = "~/Content/Uploads/PS4.jpg",
                             Rating = 5,
                             Votes = 5},
               new Product { 
                             Name = "MacBook Pro 15-inch", 
                             Price = 599, 
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
