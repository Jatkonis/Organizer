using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Models;
using Organizer.Core.Services;
using System;

namespace Organizer.Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User UserDetails { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly IUserAuthenticationService _userAuthenticationService;

        public LoginModel(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService ?? throw new ArgumentNullException(nameof(userAuthenticationService));
        }

        public IActionResult OnPost()
        {
            if (UserDetails.Login == null || UserDetails.Password == null) 
            {
                return RedirectToPage("./WrongLogins");
            }

            var loggedUser = _userAuthenticationService.LoginUser(UserDetails.Login, UserDetails.Password);

            if (loggedUser == null)
            {                
                return RedirectToPage("./WrongLogins");
            }

            TempData["Message"] = $"Welcome to Organizer {loggedUser.Name}!";
            return RedirectToPage("./Events");              
        }       
    }
}