namespace Seventh.Desafio.Domain.Models;

public class ServerModel : IModel
{
    public String? Name { get; set; }

    public String? IpAddress { get; set; }

    public Int32 Port { get; set; }
}
