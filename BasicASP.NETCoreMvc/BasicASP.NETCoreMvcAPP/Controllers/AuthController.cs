using System.Security.Claims;
using BasicASP.NETMvc.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.NETMvc.Controllers
{
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user == null || !"admin".Equals(user.UserName) || !"admin".Equals(user.PassWord))
            {
                ViewBag.Error = "UserName and PassWord is admin";
                return View();
            }

            CreateAuthCookie(user.UserName);
            AddValusToSession(user.UserName);
            return RedirectToAction("Page");
        }


        //basic points 14 please make sure this action should be authed.
        [Authorize]
        public ActionResult Page()
        {
            // # homework 1 -- redirect to movies/index
            //return View();
            return RedirectToAction("movies/index");
        }

        private void CreateAuthCookie(string userName)
        {
            //basic points 16 please add param into Cookie 
            // use cookie auth
            var claims = new[] { new Claim("UserName", userName) };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
            HttpContext.User = user;
        }

        private void AddValusToSession(string userName)
        {
            //basic points 17 Add param into Session and Seeeion key is "userName"
            HttpContext.Session.SetString("userName", userName);
        }
    }
}