using AutoMapper;
using Seventh.Desafio.Api.ViewModel;
using Seventh.Desafio.Domain.Models;

namespace Seventh.Desafio.Api.Features.ServerFeature;

public class ServerProfile : Profile
{
    public ServerProfile()
    {
        CreateMap<ServerCreateCommand, ServerModel>();
        
        CreateMap<ServerCreateViewModel, ServerCreateCommand>()
            .ConstructUsing(view => new ServerCreateCommand(
                view.Name ?? string.Empty,
                view.IpAddress ?? string.Empty,
                view.Port
            ));
    }
}
