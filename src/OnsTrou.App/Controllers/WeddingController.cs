using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnsTrou.App.Abstractions;
using OnsTrou.App.Contracts.WeddingFeature;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;

namespace OnsTrou.App.Controllers;

public sealed class WeddingController : ApiController
{
    public WeddingController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWeddingRequest request, CancellationToken cancellationToken)
    {
        //var command = request.MapToCreateWeddingCommand();
        var command = new CreateWeddingCommand();
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
