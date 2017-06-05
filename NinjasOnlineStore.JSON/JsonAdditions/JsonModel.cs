using Newtonsoft.Json;
using NinjasOnlineStore.JSON.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.JSON.JsonAdditions
{
    public class JsonModel : IJsonAddition
    {
        [JsonProperty(PropertyName = "Model")]
        public IEnumerable<string> Names { get; set; }
    }
}
