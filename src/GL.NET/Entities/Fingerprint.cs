using Newtonsoft.Json;

namespace GL.NET.Entities;

public class Fingerprint
{
    [JsonProperty("item1")]
    public int AmountOfLogins { get; set; }

    [JsonProperty("item2")]
    public DateTime LastLogin { get; set; }
}
