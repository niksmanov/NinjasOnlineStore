﻿using NinjasOnlineStore.JSON;
using NinjasOnlineStore.PostgreSQL;
using NinjasOnlineStore.SqLite;

namespace NinjasOnlineStore.App
{
    public class StartUp
    {
        static void Main()
        {
            string jsonFilePath = "../../../NinjasOnlineStore.JSON/DATA.json";
            JsonImporter.Import(jsonFilePath);

            SqLiteImporter.Import();

            PostgreSQLImporter.Import();
        }
    }
}
