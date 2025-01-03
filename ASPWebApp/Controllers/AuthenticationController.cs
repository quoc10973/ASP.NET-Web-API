﻿using ASPWebApp.Model;
using ASPWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApp.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLogin request)
        {
            try
            {
                var account = await _authenticationService.Login(request.Email, request.Password);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return Unauthorized("Unauthorized");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountRegister registerRequest)
        {
            try { 
                return Ok( await _authenticationService.Register(registerRequest));
            }
            catch (Exception ex)
            {
                return BadRequest("Email already in used, please try another email!");
            }
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                return Ok(await _authenticationService.GetCurrentUser());
            }
            catch (Exception ex)
            {
                return Unauthorized("Unauthorized");
            }
        }
    }
}
