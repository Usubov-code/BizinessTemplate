using BizinessTemplate.Data;
using BizinessTemplate.Models;
using BizinessTemplate.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizinessTemplate.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context,UserManager<CustomUser> userManager,SignInManager<CustomUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(VmRegister model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (_context.Users.Any(u => u.UserName == model.UserName))
                {

                    ModelState.AddModelError("", "UserName Movcuddur!");
                    return View(model);
                }
                else
                {
                    if (_context.Users.Any(e => e.Email == model.Email))
                    {

                        ModelState.AddModelError("", "Email movcuddur!");
                        return View(model);


                    }
                    CustomUser member = new CustomUser()
                    { Email=model.Email,
                    FullName=model.FullName,
                    UserName=model.UserName,
                    };

                    var result = await _userManager.CreateAsync(member, model.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", "Email ve ya Password duzgun secin!");
                            return View();
                        }

                    }
                    else
                    {

                        await _signInManager.SignInAsync(member, false);
                        return RedirectToAction("login", "account");

                    }


                 }

                return View();
            }

        }


        public IActionResult Login()
        {



            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(VmLogin model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            CustomUser user = _userManager.Users.FirstOrDefault(e => e.NormalizedUserName == model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "User Tapilmadi!");
                return View();


                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (!result.Succeeded)
                {

                    ModelState.AddModelError("", "Username ve ya Password sehvdir!");
                    return View();
                }

                return RedirectToAction("index", "home");


               

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {


            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
