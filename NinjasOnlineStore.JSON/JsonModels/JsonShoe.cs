using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;

namespace NinjasOnlineStore.JSON.JsonModels
{
    public class JsonShoe : IJsonObject
    {
        [JsonProperty(PropertyName = "Price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "SizeId")]
        public int SizeId { get; set; }

        [JsonProperty(PropertyName = "ColorId")]
        public int ColorId { get; set; }

        [JsonProperty(PropertyName = "BrandId")]
        public int BrandId { get; set; }

        [JsonProperty(PropertyName = "KindId")]
        public int KindId { get; set; }

        [JsonProperty(PropertyName = "ModelId")]
        public int ModelId { get; set; }
    }
}
