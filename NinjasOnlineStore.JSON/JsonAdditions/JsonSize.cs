using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonAdditions
{
    public class JsonSize : IJsonAddition
    {
        [JsonProperty(PropertyName = "Size")]
        public IEnumerable<string> Names { get; set; }
    }
}
