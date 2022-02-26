using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.DTO.Auth;
using ModelsLibrary.Models.Entities.Auth;
using ServiceLibrary.AuthorizationServices.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AuthenticationController : ControllerBase
    {
        private readonly IAuthService userService;
        private readonly IAuthManager authManager;
        public AuthenticationController(IAuthService userService, IAuthManager authManager)
        {
            this.userService = userService;
            this.authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromQuery] string user, string password, CancellationToken cancellationToken)
        {
            TokenResponse token = await userService.Authenticate(user, password, cancellationToken);
            if (token is null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost("registration")]
        public async Task<IActionResult> CreateAsync([FromBody] AuthResponseDto authResponse, CancellationToken token)
        {
            var result = await authManager.CreateAsync(authResponse, token);

            return StatusCode(result);
        }
        [Authorize]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshAsync(CancellationToken cancellationToken)
        {
            string oldRefreshToken = Request.Cookies["refreshToken"];
            string newRefreshToken = await userService.RefreshToken(oldRefreshToken, cancellationToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);
            return Ok(newRefreshToken);
        }
        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

    }
}
