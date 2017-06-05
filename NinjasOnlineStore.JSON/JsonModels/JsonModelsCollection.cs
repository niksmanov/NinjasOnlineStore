using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonModels
{
    public class JsonModelsCollection
    {
        public IEnumerable<JsonJacket> Jackets { get; set; }
        public IEnumerable<JsonPants> Pants { get; set; }
        public IEnumerable<JsonShoe> Shoes { get; set; }
        public IEnumerable<JsonSwimmingSuit> SwimmingSuits { get; set; }
        public IEnumerable<JsonTShirt> TShirts { get; set; }
    }
}
