using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [Route("t-api/v1/[controller]")]
    //[EnableRateLimiting("sliding")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<BaseApiController> _logger;

        public BaseApiController(IMapper mapper, ILogger<BaseApiController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
