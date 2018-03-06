using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;

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
                    if (await _signInManager.UserManager.CheckPasswordAsync(existingUser, password))
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
                        message.AddContent("text/html", "Thanks for registering " + username + " on Sound Store!");
                        message.SetTemplateId("7610f02c-135a-4a53-844f-ccc2003ee5a8");
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

        [HttpGet]
        public IActionResult passwordReset()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordReset(string email)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                string token = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
                token = System.Net.WebUtility.UrlEncode(token);

                string currentUrl = Request.GetDisplayUrl();
                System.Uri uri = new Uri(currentUrl);
                string resetUrl = uri.GetLeftPart(UriPartial.Authority);
                resetUrl += "/account/newpassword?id=" +token + "&email=" + email;

                SendGrid.Helpers.Mail.SendGridMessage message = new SendGrid.Helpers.Mail.SendGridMessage();
                message.AddTo(email);
                message.Subject = "Your password reset token";
                message.SetFrom("admin@SoundStore.com");
                message.AddContent("text/plain", resetUrl);
                message.AddContent("text/html", string.Format("<a href=\"{0}\">{0}</a>", resetUrl));
                await _sendGridClient.SendEmailAsync(message);
            }

            //return RedirectToAction("Reset Sent");
            return View();
        }

        public async Task<IActionResult> NewPassword(string email)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPassword(string id, string email, string password)
        {
            string originalToken = id;
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.UserManager.ResetPasswordAsync(user, originalToken, password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", new { resetSuccessful = true });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View();
        }
    }
}