using ConsoleApp.Data.Scaffolded;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp48
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var localConnectionString = configuration.GetConnectionString("northwind");

            Console.WriteLine(localConnectionString);

            //
            //            List<Category> query;
            //            using (var db = new NorthwindContext())
            //            {
            //                query = db.Categories
            //                    .Where(x => x.CategoryId > 2).ToList();
            //            }
            //
            //            var res = query.ToList();
            //            foreach (var item in res)
            //            {
            //                Console.WriteLine(item.CategoryName);
            //            }

            using (var db = new NorthwindContext())
            {
                var shop = new Shop()
                {
                    Name = "Test",
                };
                db.Shops.Add(shop);
                db.SaveChanges();
            
                var wine1 = new Wine()
                {
                    ShopId = shop.ShopId,
                    Name = "Dark House"
                };
                var wine2 = new Wine()
                {
                    ShopId = shop.ShopId,
                    Name = "Maison du House"
                };
            
                db.Wines.Add(wine1);
                db.Wines.Add(wine2);
                db.SaveChanges();
            }
            using (var db = new NorthwindContext())
            {
                var wine1 = new Wine()
                {
                    Name = "Quick House"
                };
                var wine2 = new Wine()
                {
                    Name = "Maison du bois"
                };
                var shop = new Shop()
                {
                    Name = "Related Test",
                    Wines = new List<Wine>()
                    {
                        wine1, wine2
                    }
                };
                db.Shops.Add(shop);
                db.SaveChanges();
            }

        }
    }
}
