using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnsTrou.Application.Features.WeddingFeature.Commands.CreateWedding;
using OnsTrou.Presentation.Abstractions;
using OnsTrou.Presentation.Contracts.WeddingFeature;
using OnsTrou.Presentation.Mappers.WeddingFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Presentation.Controllers
{
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
            
            if(result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
