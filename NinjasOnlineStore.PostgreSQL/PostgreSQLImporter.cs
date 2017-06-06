using NinjasOnlineStore.PostgreSQL.Models;
using System;
using System.Linq;

namespace NinjasOnlineStore.PostgreSQL

{
    public class PostgreSQLImporter
    {
        private static PostgreSQLDbContext PostgreSQLDbConnecton()
        {
            var database = new PostgreSQLDbContext();
            return database;
        }

        public static void Import()
        {
            var database = PostgreSQLDbConnecton();

            if (database.Stores.FirstOrDefault() == null)
            {
                Console.WriteLine("Adding stores availability...");
                var firstStore = new Store { Name = "Dianabad NinjaStore", Jackets = false, Pants = true, Shoes = true, SwimmingSuits = true, TShirts = false };
                var secondStore = new Store { Name = "Mladost NinjaStore", Jackets = true, Pants = true, Shoes = true, SwimmingSuits = true, TShirts = true };
                var thirdStore = new Store { Name = "St.Grad NinjaStore", Jackets = false, Pants = false, Shoes = true, SwimmingSuits = false, TShirts = false };
                var fourthStore = new Store { Name = "Iztok NinjaStore", Jackets = false, Pants = true, Shoes = true, SwimmingSuits = true, TShirts = true };
                var fifthStore = new Store { Name = "Trakia NinjaStore", Jackets = false, Pants = true, Shoes = true, SwimmingSuits = true, TShirts = false };
                var sixthStore = new Store { Name = "Smirnenski NinjaStore", Jackets = true, Pants = true, Shoes = false, SwimmingSuits = true, TShirts = true };
                var seventhStore = new Store { Name = "Kurshiaka NinjaStore", Jackets = true, Pants = false, Shoes = true, SwimmingSuits = true, TShirts = true };
                var eightStore = new Store { Name = "Trakata NinjaStore", Jackets = false, Pants = false, Shoes = true, SwimmingSuits = true, TShirts = true };
                var ninethStore = new Store { Name = "Vuzrajdane NinjaStore", Jackets = false, Pants = true, Shoes = true, SwimmingSuits = false, TShirts = false };
                var tenthStore = new Store { Name = "Izgrev NinjaStore", Jackets = true, Pants = true, Shoes = true, SwimmingSuits = false, TShirts = false };

                database.Stores.Add(firstStore);
                database.Stores.Add(secondStore);
                database.Stores.Add(thirdStore);
                database.Stores.Add(fourthStore);
                database.Stores.Add(fifthStore);
                database.Stores.Add(sixthStore);
                database.Stores.Add(seventhStore);
                database.Stores.Add(eightStore);
                database.Stores.Add(ninethStore);
                database.Stores.Add(tenthStore);

                database.SaveChanges();
                Console.WriteLine("Stores availability added successfully!");
            }
        }
    }
}
