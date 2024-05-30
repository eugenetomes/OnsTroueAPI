using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnsTrou.App.Abstractions;
using OnsTrou.App.Contracts.WeddingFeature;
using OnsTrou.App.Mappers.WeddingFeature;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;
using OnsTrou.Application.Features.WeddingFeature.Commands.UpdateBride;
using OnsTrou.Application.Features.WeddingFeature.Queries.GetMyWedding;

namespace OnsTrou.App.Controllers;

public sealed class WeddingController : ApiController
{
    public WeddingController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWeddingRequest request, CancellationToken cancellationToken)
    {
        var command = request.MapToCreateWeddingCommand();
        
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetMyWedding(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetMyWeddingQuery(), cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }

    [HttpPut]
    [Route("Bride")]
    public async Task<IActionResult> UpdateBride([FromBody] UpdateBrideRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateBrideCommand(request.Name, request.Surname, request.PersonalMessage), cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
