using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Factories;
using StudVoice.BLL.Helpers;
using StudVoice.BLL.Services.Interfaces;
using StudVoice.DAL;

namespace StudVoice.API.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
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