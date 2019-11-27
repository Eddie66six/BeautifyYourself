using Core.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        private readonly ErrorEvent _errorEvent;
        public BaseApiController(ErrorEvent errorEvent)
        {
            _errorEvent = errorEvent;
        }
        public Task<ObjectResult> CreateResponse(object result)
        {
            return Task.FromResult(_errorEvent.IsError() ? StatusCode((int)HttpStatusCode.BadRequest, _errorEvent.GetErrorMessages()) : StatusCode((int)HttpStatusCode.OK, result));
        }
    }
}