using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnsTrou.Presentation.Abstractions
{
    [Route("api/[Controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender _sender;

        protected ApiController(ISender sender) => _sender = sender;


    }
}
