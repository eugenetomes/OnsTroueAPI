using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnsTrou.App.Abstractions;
using OnsTrou.App.Contracts.WeddingFeature;
using OnsTrou.App.Contracts.WeddingGuestFeature;

namespace OnsTrou.App.Controllers;

public sealed class WeddingGuestController : ApiController
{
    public WeddingGuestController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWeddingGuestRequest request, CancellationToken cancellationToken)
    {
        var command = request.MapToCreateWeddingGuestCommand();

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
