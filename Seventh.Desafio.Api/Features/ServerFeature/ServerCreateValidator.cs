using System.Net;
using FluentValidation;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerCreateValidator : AbstractValidator<ServerCreateCommand>
{
    public ServerCreateValidator()
    {
        RuleFor(x => x.IpAddress).NotNull().NotEmpty().Must(ValidateIp).MaximumLength(15);
        RuleFor(x => x.Port).NotNull().NotEmpty().Must(ValidatePort);
        RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(160);
    }

    private bool ValidatePort(int arg) => arg > 0 && arg < 65535;

    private bool ValidateIp(string arg)
    {
        try
        {
            return IPAddress.TryParse(arg, out IPAddress? _);
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
