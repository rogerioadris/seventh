using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Seventh.Desafio.Api.Pipelines;

public class FluentValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FluentValidationPipeline(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Verifica se foi criado um validator para a Queries/Command
        if (!_validators.Any())
            throw new ValidationException(new List<ValidationFailure>(){
                new ValidationFailure("Validation", "There is no validation implemented for this Command/Query")
            });

        // Instância o contexto de validação
        var context = new ValidationContext<TRequest>(request);

        // Valida dados
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        // Verifica se encontrou erro na validação
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        return failures.Count != 0
            ? throw new ValidationException(failures.Select(item => new ValidationFailure(item.PropertyName, item.ErrorMessage)))
            : await next();
    }
}
