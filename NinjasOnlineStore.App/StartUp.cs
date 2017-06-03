namespace NinjasOnlineStore.App
{
    public class StartUp
    {
        static void Main()
        {
            string jsonFilePath = "../../DATA.json";
            DataImporter.JsonParser(jsonFilePath);
        }
    }
}
