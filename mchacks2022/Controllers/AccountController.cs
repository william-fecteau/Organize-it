﻿using System.Threading.Tasks;
using mchacks2022.DTOs;
using mchacks2022.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace mchacks2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly TokenProviderService _tokenProviderService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(SignInManager<IdentityUser> signInManager, TokenProviderService tokenProviderService)
        {
            _signInManager = signInManager;
            _tokenProviderService = tokenProviderService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (!result.Succeeded) return BadRequest();

            var token = await _tokenProviderService.GetTokenAsync(request.Username);
            if (string.IsNullOrEmpty(token)) return Problem();

            return Ok(new LoginResponse()
            {
                Jwt = token
            });
        }
    }
}
