using Newtonsoft.Json;
using NinjasOnlineStore.App.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.App.JsonAdditions
{
    public class JsonColor : IJsonAddition
    {
        [JsonProperty(PropertyName = "Color")]
        public IEnumerable<string> Names { get; set; }
    }
}
