using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DiningApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiningApp.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
       /* private IUserService _userService;

        public LoginModel(UserService userService)
        {
            _userService = userService;
        }
        */
        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            Console.WriteLine("Posting here..");
            
            // Validate login
            /*
            if(string.IsNullOrWhiteSpace(username)&&string.IsNullOrWhiteSpace(password))
            {
              Console.WriteLine("[INFO]********************************Identification failed"); 
            }
            else{
            _userService.ValidateLogin(username,password);
            
            }
            */

            // TODO get claims here by username from database.
 
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, username),
                new Claim("Role", "loggedin")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(Url.Content("~/"));
        }
    }
}