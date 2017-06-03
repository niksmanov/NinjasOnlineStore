using Newtonsoft.Json;
using NinjasOnlineStore.App.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.App.JsonAdditions
{
    public class JsonSize : IJsonAddition
    {
        [JsonProperty(PropertyName = "Size")]
        public IEnumerable<string> Names { get; set; }
    }
}
