using FluentValidation;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerFindValidator : AbstractValidator<ServerFindQuery>
{
    public ServerFindValidator()
    {
        RuleFor(x => x.Uid)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}
