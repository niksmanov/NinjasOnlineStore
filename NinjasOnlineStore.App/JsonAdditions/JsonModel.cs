using Newtonsoft.Json;
using NinjasOnlineStore.App.Contracts;
using System.Collections.Generic;

namespace NinjasOnlineStore.App.JsonAdditions
{
    public class JsonModel : IJsonAddition
    {
        [JsonProperty(PropertyName = "Model")]
        public IEnumerable<string> Names { get; set; }
    }
}
