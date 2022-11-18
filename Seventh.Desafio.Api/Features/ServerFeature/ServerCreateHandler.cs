using AutoMapper;
using MediatR;
using Seventh.Desafio.Domain.Interfaces.Repository;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

internal class ServerCreateHandler : IRequestHandler<ServerCreateCommand, ServerModel>
{
    private readonly IServerRepository _repository;

    private readonly IMapper _mapper;

    private readonly IPublisher _publisher;

    public ServerCreateHandler(IServerRepository repository, IMapper mapper, IPublisher publisher)
    {
        _repository = repository;
        _mapper = mapper;
        _publisher = publisher;
    }

    public async Task<ServerModel> Handle(ServerCreateCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<ServerModel>(request);
        if (await _repository.InsertAsync(model, cancellationToken))
            await _publisher.Publish(new ServerCreateNotification(model.Uid), cancellationToken);

        return model;
    }
}
