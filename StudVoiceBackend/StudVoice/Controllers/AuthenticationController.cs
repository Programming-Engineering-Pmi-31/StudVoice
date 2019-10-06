﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudVoice.BLL.DTOs;
using StudVoice.BLL.Factories;
using StudVoice.BLL.Services.Interfaces;

namespace StudVoice.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : Controller
    {
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