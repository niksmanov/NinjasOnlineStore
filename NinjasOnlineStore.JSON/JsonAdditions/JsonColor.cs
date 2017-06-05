using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonAdditions
{
    public class JsonColor : IJsonAddition
    {
        [JsonProperty(PropertyName = "Color")]
        public IEnumerable<string> Names { get; set; }
    }
}
