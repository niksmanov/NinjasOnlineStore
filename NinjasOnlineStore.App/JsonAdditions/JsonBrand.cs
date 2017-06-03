using Newtonsoft.Json;
using NinjasOnlineStore.App.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.App.JsonAdditions
{
    public class JsonBrand : IJsonAddition
    {
        [JsonProperty(PropertyName = "Brand")]
        public IEnumerable<string> Names { get; set; }
    }
}
