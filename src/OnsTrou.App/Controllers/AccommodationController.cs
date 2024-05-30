using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnsTrou.App.Abstractions;
using OnsTrou.App.Contracts.WeddingFeature;
using OnsTrou.Application.Features.AccommodationFeature.Queries;
using OnsTrou.Application.Features.AccommodationFeature.Queries.GetAllAccommodation;

namespace OnsTrou.App.Controllers
{
    public sealed class AccommodationController : ApiController
    {
        public AccommodationController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<AccommodationResponse>> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllAccommodationQuery();
            var result = await _sender.Send(query, cancellationToken);

            if (result.IsSuccess)
            {
                return result.Value;
            }
            throw new Exception(result.Error.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccommodationRequest request, CancellationToken cancellationToken)
        {
            var command = request.MapToCreateAccommodationCommand();

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }

        ///
    }
}
