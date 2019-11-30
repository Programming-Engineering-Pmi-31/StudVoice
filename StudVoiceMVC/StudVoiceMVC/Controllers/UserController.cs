using Microsoft.AspNetCore.Mvc;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Factories;
using StudVoice.BLL.Services.Interfaces;
using System.Threading.Tasks;

namespace StudVoiceMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IUserService _userService;

        public UserController(IServiceFactory serviceFactory)
        {
            _userService = serviceFactory.UserService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserDTO obj)
        {
            obj.Id = id;
            var result = await _userService.UpdateAsync(obj);
            return result != null
                ? Json(result)
                : (IActionResult)BadRequest("User doesn't exist");
        }

        [HttpPut("{id}/password")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordDTO changePassword)
        {
            var user = await _userService.GetAsync(id);
            var result = await _userService.UpdatePasswordAsync(user, changePassword.Password);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO obj)
        {
            return CreatedAtAction(nameof(Create), await _userService.CreateAsync(obj));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}