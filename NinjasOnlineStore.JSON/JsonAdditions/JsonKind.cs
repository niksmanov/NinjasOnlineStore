using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonAdditions
{
    public class JsonKind : IJsonAddition
    {
        [JsonProperty(PropertyName = "Kind")]
        public IEnumerable<string> Names { get; set; }
    }
}
