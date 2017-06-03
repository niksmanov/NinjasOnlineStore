using Newtonsoft.Json;
using NinjasOnlineStore.App.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.App.JsonAdditions
{
    public class JsonKind : IJsonAddition
    {
        [JsonProperty(PropertyName = "Kind")]
        public IEnumerable<string> Names { get; set; }
    }
}
