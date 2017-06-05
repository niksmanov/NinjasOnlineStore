using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonAdditions
{
    public class JsonBrand : IJsonAddition
    {
        [JsonProperty(PropertyName = "Brand")]
        public IEnumerable<string> Names { get; set; }
    }
}
