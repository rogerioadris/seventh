using System.Net.Mime;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seventh.Desafio.Api.Features.ServerFeature;
using Seventh.Desafio.Api.ViewModel;

namespace Seventh.Desafio.Api.Controllers;

[ApiController]
[Route("api/servers")]
public class ServerController : ControllerBase
{
    private readonly ISender _sender;

    private readonly IMapper _mapper;

    public ServerController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    /// <summary>
    /// Criar um novo servidor​
    /// </summary>
    /// <param name="view"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAction([FromBody] ServerCreateViewModel view, CancellationToken cancellation)
    {
        var command = _mapper.Map<ServerCreateCommand>(view);
        var model = await _sender.Send(command, cancellation);
        return model.Uid == Guid.Empty ? BadRequest() : CreatedAtAction(nameof(CreateAction), new { uid = model.Uid }, model);
    }

    /// <summary>
    /// Remover um servidor existente​
    /// </summary>
    /// <param name="serverId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{serverId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAction(Guid serverId, CancellationToken cancellation)
    {
        return await _sender.Send(new ServerDeleteCommand(serverId), cancellation) ? Accepted() : NotFound();
    }

    /// <summary>
    /// Recuperar um servidor existente​
    /// </summary>
    /// <param name="serverId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("{serverId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAction(Guid serverId, CancellationToken cancellation)
    {
        var model = await _sender.Send(new ServerFindQuery(serverId), cancellation);
        if (model != null)
            return Ok(model);

        return NotFound();
    }

    /// <summary>
    /// Checar disponibilidade de um servidor​
    /// </summary>
    /// <param name="serverId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("available/{serverId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckAvailableAction(Guid serverId, CancellationToken cancellation)
    {
        return await _sender.Send(new ServerCheckQuery(serverId), cancellation) ? Accepted() : NotFound();
    }

    /// <summary>
    /// Listar todos os servidores​
    /// </summary>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("servers")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAction([FromQuery] short page, [FromQuery] byte limit, CancellationToken cancellation)
    {
        return Ok(await _sender.Send(new ServerPaginationQuery(page, limit), cancellation));
    }
}
