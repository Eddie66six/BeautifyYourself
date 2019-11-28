using Core.Core;
using Core.Core.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core.Api.Controllers.Auth
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IAuthApplication _authApplication;
        public UserController(ErrorEvent errorEvent, IAuthApplication authApplication) : base(errorEvent)
        {
            _authApplication = authApplication;
        }

        [HttpPost]
        public Task<ObjectResult> Login(UserViewModel user)
        {
            return CreateResponse(_authApplication.Login(user));
        }
    }
}