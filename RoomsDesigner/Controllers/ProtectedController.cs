using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomsDesigner.Api.Requests.User;
using System.Linq;

namespace RoomsDesigner.Api.Controllers
{
    /// <summary>
    /// User
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProtectedController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("method")]
        public JsonResult Method()
        {
            return new JsonResult("Good request!");
        }

        [Authorize()]
        //[Authorize(Roles = "Buyer")]
        //[Authorize(Roles = "view-profile")]
        //[Authorize(AuthenticationSchemes = "MyCustomScheme")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Policies.RequireAge18Plus)]
        [HttpPost("methodRequiringAuthorization")]
        public JsonResult MethodRequiringAuthorization()
        {
            //PassThroughAuthorizationHandler
            return new JsonResult("Good authorization request!");
        }

        [HttpPost("GetUserInfo")]
        public UserDto GetUserInfo()
        {
            var test = User;
            return new UserDto
            {
                Scheme = HttpContext.User.Identity.AuthenticationType,
                IsAuthenticated = HttpContext.User.Identity.IsAuthenticated,
                Claims = HttpContext.User.Claims
                    .Select(claim => (object)new
                    {
                        claim.Type,
                        claim.Value
                    }).ToList()
            };
        }
    }
}
