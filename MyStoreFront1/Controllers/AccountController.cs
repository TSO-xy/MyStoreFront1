﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStoreFront1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        // GET: /<controller>/
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {

            return Content("You can only see this if you're signed in!");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() //GET
        {
            //_signInManager.SignInAsync().Wait();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser existingUser = _signInManager.UserManager.FindByNameAsync(username).Result;
                if (existingUser != null)
                {
                    //user found. try validating pw
                    if(_signInManager.UserManager.CheckPasswordAsync(existingUser, password).Result)
                    {
                        _signInManager.SignInAsync(existingUser, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("username", "Username or password is incorrect");   
                    }
                }
                else
                {
                    ModelState.AddModelError("username", "Username or password is incorrect");
                }
            }
            else
            {
                
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string username, string password)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser(username);
                var userResult = _signInManager.UserManager.CreateAsync(newUser).Result;
                if (userResult.Succeeded)
                {
                    var passwordResult = _signInManager.UserManager.AddPasswordAsync(newUser, password).Result;
                    if (passwordResult.Succeeded)
                    {
                        _signInManager.SignInAsync(newUser, false).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        _signInManager.UserManager.DeleteAsync(newUser).Wait();
                    }
                }
                else
                {
                    foreach (var error in userResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();
        }
    }
}