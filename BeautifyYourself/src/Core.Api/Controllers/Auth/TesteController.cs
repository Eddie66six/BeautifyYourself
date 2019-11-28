using Core.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : BaseApiController
    {
        public TesteController(ErrorEvent errorEvent) : base(errorEvent)
        {
        }

        [HttpGet]
        public Task<ObjectResult> Get()
        {
            return CreateResponse(true);
        }
    }
}