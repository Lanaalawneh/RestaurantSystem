using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restorent.Areas.Admin.ViewModels;

namespace Restorent.Areas.Admin.Controllres
{

    [Area("Admin")]


    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }




        // GET: AcconutController
        public ActionResult Register()
        {
            return View();
        }

        
        // POST: AcconutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "UserName Or PassWord Is incorrect");
                    return View();
                }

                var User = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email
                };

                var Res = UserManager.CreateAsync(User , collection.Password).Result;
                if (Res.Succeeded)
                {
                    SignInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError("", "User Name or Password is incorect");
                return View();

            }
            catch
            {
                return View();
            }
        }



        // GET: AcconutController/Edit/5
        public ActionResult Login()
        {
            return View();
        }



        // POST: AcconutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "UserName Or PassWord Is incorrect");
                    return View();
                }

                var Res = SignInManager.PasswordSignInAsync(collection.Email, collection.Password, isPersistent: collection.RememberMe, false).Result;

                if (Res.Succeeded)
                {
                    return RedirectToAction("Index", "MasterMenu");
                }


                ModelState.AddModelError("", "UserName Or PassWord Is incorrect");
               
                return View();

            }
            catch
            {
                return View();
            }
        }



        // GET: AcconutController/Delete/5
        public  ActionResult LogOut(int id)
        { 
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

       
    }
}
