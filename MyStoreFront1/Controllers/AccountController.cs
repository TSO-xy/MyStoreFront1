using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore;
using MyStoreFront1.Models;

namespace MyStoreFront1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this._signInManager = signInManager;
        }


        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Index()
        {

            return Content("Sign in to view content.");
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

        [HttpPost] //optimal threading (asynchronous)
        public async Task<IActionResult> Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser existingUser = await _signInManager.UserManager.FindByNameAsync(username);
                if (existingUser != null)
                {
                    //user found. try validating pw
                    if(await _signInManager.UserManager.CheckPasswordAsync(existingUser, password))
                    {
                        _signInManager.SignInAsync(existingUser, false).Wait();
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
        public async Task<IActionResult> Register(string username, string password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser(username);
                var userResult = await _signInManager.UserManager.CreateAsync(newUser);
                if (userResult.Succeeded)
                {
                    var passwordResult = await _signInManager.UserManager.AddPasswordAsync(newUser, password);
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