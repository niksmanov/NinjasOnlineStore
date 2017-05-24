using NinjasOnlineStore.Data;
using NinjasOnlineStore.Models;
using System;
using System.Collections.Generic;

namespace NinjasOnlineStore.App
{
    public class DataImporter
    {
        private static NinjasOnlineStoreDbContext DbConnecton()
        {
            var database = new NinjasOnlineStoreDbContext();
            return database;
        }

        public static void TestGenerateSportItems()
        {
            Console.WriteLine("Adding new data...");
            var database = DbConnecton();
            //Enables faster uploading for many records
            //database.Configuration.AutoDetectChangesEnabled = false;
            //database.Configuration.ValidateOnSaveEnabled = false;

            var sportItemsList = new List<SportItem>();

            var sportItem = new SportItem
            {
                Name = "Mnogo qk sport item"
            };
            sportItemsList.Add(sportItem);

            database.SportItems.AddRange(sportItemsList);
            database.SaveChanges();
            Console.WriteLine("Sport items added successfully!");
            //database.Configuration.AutoDetectChangesEnabled = true;
            //database.Configuration.ValidateOnSaveEnabled = true;
        }

        public static void JsonParser()
        {
            //JSON objects
        }
    }
}
