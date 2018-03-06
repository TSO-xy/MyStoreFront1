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

        private SendGrid.SendGridClient _sendGridClient;

        public AccountController(SignInManager<ApplicationUser> signInManager, SendGrid.SendGridClient sendGridClient)
        {
            this._signInManager = signInManager;
            this._sendGridClient = sendGridClient;
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
        public async Task<IActionResult> Register(string email, string username, string password)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser();
                newUser.Email = email;
                newUser.UserName = username;
                var userResult = await _signInManager.UserManager.CreateAsync(newUser);
                if (userResult.Succeeded)
                {
                    var passwordResult = await _signInManager.UserManager.AddPasswordAsync(newUser, password);
                    if (passwordResult.Succeeded)
                    {
                        //SendGrid.SendGridClient sendGridClient = new SendGrid.SendGridClient("api_key");
                        SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                        message.AddTo(email);
                        message.Subject = "Welcome to the Sound Store!";
                        message.SetFrom("admin@soundstore.com");
                        message.AddContent("text/plain", "Thanks for registering " + username + " on Sound Store!");
                        await _sendGridClient.SendEmailAsync(message);

                        await _signInManager.SignInAsync(newUser, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(error.Code, error.Description);
                        }
                        await _signInManager.UserManager.DeleteAsync(newUser);
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