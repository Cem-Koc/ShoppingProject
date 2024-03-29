﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Entity.DTOs.Users;
using ShoppingProject.Entity.Entities;

namespace ShoppingProject.WebUl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,userLoginDto.Password,userLoginDto.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new {Area = "Admin"});
                    }
                    else
                    {
                        ModelState.AddModelError("","E-posta adresiniz yada şifreniz hatalıdır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz yada şifreniz hatalıdır.");
                    return View();
                }
            }
            else
            {
                return View();
            }            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {Area=""});
        }
    }
}
