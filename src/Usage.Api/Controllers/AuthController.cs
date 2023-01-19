using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ocdata.Operations.Authentication;
using Usage.Application.Services.BaseServices;

namespace Usage.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IUserService userService, IJwtTokenManager jwtTokenManager, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _jwtTokenManager = jwtTokenManager ?? throw new ArgumentNullException(nameof(jwtTokenManager));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [AllowAnonymous]
        [HttpPost(nameof(Auth))]
        public async Task<IActionResult> Auth(string username, string password)
        {
            bool isValid = await _userService.IsValidUserInformation(username, password);
            if (isValid)
            {
                var tokenString = _jwtTokenManager.GenerateJwtToken(username);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }

        [Authorize]
        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            string authenticatedUserName = _httpContextAccessor.HttpContext.Items["User"].ToString() ?? string.Empty;
            
            var currentUser = await _userService.GetUserDetails(authenticatedUserName);

            return Ok(currentUser);

        }

      
    }
}
