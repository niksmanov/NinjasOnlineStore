using NinjasOnlineStore.PostgreSQL.Models;
using System;
using System.Linq;
using System.Text;

namespace NinjasOnlineStore.PostgreSQL

{
    public class PostgreSQLImporter : IPostgreSQLImporter
    {
        private readonly IPgDatabase database;
        private readonly StringBuilder builder;
        public PostgreSQLImporter(IPgDatabase database, StringBuilder builder)
        {
            this.database = database;
            this.builder = builder;
        }
        public string Import()
        {
            if (this.database.Stores.FirstOrDefault() == null)
            {
                this.builder.AppendLine("Adding stores availability...");
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

                this.database.Stores.Add(firstStore);
                this.database.Stores.Add(secondStore);
                this.database.Stores.Add(thirdStore);
                this.database.Stores.Add(fourthStore);
                this.database.Stores.Add(fifthStore);
                this.database.Stores.Add(sixthStore);
                this.database.Stores.Add(seventhStore);
                this.database.Stores.Add(eightStore);
                this.database.Stores.Add(ninethStore);
                this.database.Stores.Add(tenthStore);

                this.database.SaveChanges();
                this.builder.AppendLine("Stores availability added successfully!");
            }

            return this.builder.ToString();
        }
    }
}
