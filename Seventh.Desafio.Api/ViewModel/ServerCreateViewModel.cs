using System.Text.Json.Serialization;

namespace Seventh.Desafio.Api.ViewModel;

public class ServerCreateViewModel
{
    public String? Name { get; set; }

    [JsonPropertyName("ip")]
    public String? IpAddress { get; set; }

    public Int32 Port { get; set; }
}
