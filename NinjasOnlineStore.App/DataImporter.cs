using NinjasOnlineStore.Data;
using System;

namespace NinjasOnlineStore.App
{
    public class DataImporter
    {
        private static NinjasOnlineStoreDbContext DbConnecton()
        {
            var database = new NinjasOnlineStoreDbContext();
            return database;
        }

        public static void JsonParser()
        {
            Console.WriteLine("Adding new data...");
            var database = DbConnecton();
            //Enables faster uploading for many records
            //database.Configuration.AutoDetectChangesEnabled = false;
            //database.Configuration.ValidateOnSaveEnabled = false;

            database.Database.CreateIfNotExists(); //only if we don't have any records

            database.SaveChanges();
            Console.WriteLine("Data added successfully!");
            //database.Configuration.AutoDetectChangesEnabled = true;
            //database.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
