using FluentValidation;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerPaginationValidator : AbstractValidator<ServerPaginationQuery>
{
    public ServerPaginationValidator()
    {
        RuleFor(x => x.Page).NotNull().Must(x => x >= 1 && x <= short.MaxValue);
        RuleFor(x => x.Records).NotNull().Must(x => x >= 1 && x <= byte.MaxValue);
    }
}
