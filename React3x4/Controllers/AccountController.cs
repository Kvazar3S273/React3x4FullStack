﻿using DataLib.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using React3x4.Constants;
using React3x4.Models;

namespace React3x4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            //return BadRequest(new {
            //    message="Такий користувач вже існує!"
            //});


            //AccountValidator validRules = new();
            //var res = validRules.ValidateAsync(model);

            //якщо модель не валідна:
            //if (!res.Result.IsValid)
            //{
            //    return BadRequest(res.Result.Errors);
            //}

            //шукаю користувача по емейлу.
            //var user = await _userManager.FindByEmailAsync(model.Email);

            //якщо такий користувач вже існує:
            //if (user != null)
            //{
            //    return BadRequest(new { message = "Такий користувач вже існує" });
            //}

            var user = new AppUser
            {
                Email = model.Email
            };

            var role = new AppRole
            {
                Name = Roles.User
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(new { message = result.Errors });

            await _userManager.AddToRoleAsync(user, role.Name);

            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok();
        }
    }
}
