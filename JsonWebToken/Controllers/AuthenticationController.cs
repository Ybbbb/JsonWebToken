using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonWebToken.Request;
using JsonWebToken.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        public AuthenticationController(IAuthenticateService authService)
        {
            this._authService = authService;
        }

        [AllowAnonymous] //在授权期间跳过 System.Web.Mvc.AuthorizeAttribute 的控制器和操作
        [HttpPost, Route("requestToken")]
        public ActionResult RequestToken([FromBody] LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}