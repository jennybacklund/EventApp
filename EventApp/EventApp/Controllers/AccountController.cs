using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApp.Data;
using EventApp.Models;
using EventApp.RequestObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers
{
    public class AccountController : Controller
    {
        private EventAppContext db;
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;


        public AccountController(EventAppContext db, 
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager
            )
        {

            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestObject request){

            if(!ModelState.IsValid || request.Password != request.ConfirmPassword)
            {
                return View();
            }

            AppUser user = new AppUser {

                Email = request.Email,
                UserName = request.UserName
            };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if(!result.Succeeded)
            {
                ViewData["Errors"] = result.Errors;

                return View();
            }

            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestObject request)
        {
            if(!ModelState.IsValid)
            {
                return View();    
            }

            var result = await signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if(!result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("MinSida", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Account");

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event myEvent)
        {
            db.Events.Add(myEvent);

            db.SaveChanges();

            return RedirectToAction("MinSida", "Home");
        }
    }
}