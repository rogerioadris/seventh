using FluentValidation;
using Seventh.Desafio.Domain.Interfaces.Repository;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerDeleteValidator : AbstractValidator<ServerDeleteCommand>
{
    private readonly IServerRepository _repository;

    public ServerDeleteValidator(IServerRepository repository)
    {
        RuleFor(x => x.Uid)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .MustAsync(CheckExistsUid);

        _repository = repository;
    }

    private Task<bool> CheckExistsUid(Guid arg1, CancellationToken arg2)
        => _repository.AnyAsync(arg1, arg2);
}
