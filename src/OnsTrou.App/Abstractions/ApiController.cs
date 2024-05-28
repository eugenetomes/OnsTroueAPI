using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnsTrou.App.Abstractions
{
    [Route("api/[Controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender _sender;

        protected ApiController(ISender sender) => _sender = sender;


    }
}
