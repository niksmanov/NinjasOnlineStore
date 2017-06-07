using NinjasOnlineStore.SqLite.Models;
using NinjasOnlineStore.SQLite;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NinjasOnlineStore.SqLite
{
    public class SqLiteImporter
    {
        public static SQLiteDbContext SQLiteDbConnecton()
        {
            var database = new SQLiteDbContext();
            return database;
        }


        public static void Import()
        {
            var database = SQLiteDbConnecton();

            if (database.Shops.FirstOrDefault() == null)
            {
                Console.WriteLine("Adding shops and cities...");
                var firstShop = new Shop { Name = "Dianabad NinjaStore", CityId = 1 };
                var secondShop = new Shop { Name = "Mladost NinjaStore", CityId = 1 };
                var thirdShop = new Shop { Name = "St.Grad NinjaStore", CityId = 1 };
                var fourthShop = new Shop { Name = "Iztok NinjaStore", CityId = 1 };

                var fifthShop = new Shop { Name = "Trakia NinjaStore", CityId = 2 };
                var sixthShop = new Shop { Name = "Smirnenski NinjaStore", CityId = 2 };
                var seventhShop = new Shop { Name = "Kurshiaka NinjaStore", CityId = 2 };

                var eightShop = new Shop { Name = "Trakata NinjaStore", CityId = 3 };
                var ninethShop = new Shop { Name = "Vuzrajdane NinjaStore", CityId = 3 };
                var tenthShop = new Shop { Name = "Izgrev NinjaStore", CityId = 3 };

                var firstShopsCollection = new List<Shop>();
                firstShopsCollection.Add(firstShop);
                firstShopsCollection.Add(secondShop);
                firstShopsCollection.Add(thirdShop);
                firstShopsCollection.Add(fourthShop);

                var secondShopsCollection = new List<Shop>();
                secondShopsCollection.Add(fifthShop);
                secondShopsCollection.Add(sixthShop);
                secondShopsCollection.Add(seventhShop);

                var thirdShopsCollection = new List<Shop>();
                thirdShopsCollection.Add(eightShop);
                thirdShopsCollection.Add(ninethShop);
                thirdShopsCollection.Add(tenthShop);

                var firstCity = new City { Name = "Sofia", Shops = firstShopsCollection };
                var secondCity = new City { Name = "Plovdiv", Shops = secondShopsCollection };
                var thirdCity = new City { Name = "Varna", Shops = thirdShopsCollection };

                database.Shops.AddRange(firstShopsCollection);
                database.Shops.AddRange(secondShopsCollection);
                database.Shops.AddRange(thirdShopsCollection);

                database.Cities.Add(firstCity);
                database.Cities.Add(secondCity);
                database.Cities.Add(thirdCity);

                database.SaveChanges();
                Console.WriteLine("Shops and cities added successfully!");
            }
        }
    }
}
