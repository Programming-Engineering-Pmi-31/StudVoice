using Microsoft.AspNetCore.Mvc;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Factories;
using StudVoice.BLL.Services.Interfaces;
using System.Threading.Tasks;

namespace StudVoiceMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IServiceFactory serviceFactory)
        {
            _authenticationService = serviceFactory.AuthenticationService;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO credentials)
        {
            var result = await _authenticationService.SignInAsync(credentials);
            return result != null
                ? Json(result)
                : (IActionResult)BadRequest();
        }

        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDTO token)
        {
            var result = await _authenticationService.TokenAsync(token);
            return result != null
                ? Json(result)
                : (IActionResult)Forbid();
        }
    }
}