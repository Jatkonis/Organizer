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
        public User user { get; set; }

        [TempData]
        public string Message { get; set; }

        private readonly IUserAuthentication _userAuthentication;
        private readonly IUserLoginStatus _userLoginStatus;

        public LoginModel(IUserAuthentication userAuthentication, IUserLoginStatus userLoginStatus)
        {
            _userAuthentication = userAuthentication ?? throw new ArgumentNullException(nameof(userAuthentication)); ;
            _userLoginStatus = userLoginStatus ?? throw new ArgumentNullException(nameof(userLoginStatus)); ;
        }

        public IActionResult OnPost()
        {
            var logedInUser = _userAuthentication.GetUser(user.Login, user.Password);
            if (logedInUser == null)
            {                
                return RedirectToPage("./WrongLogins");
            }
            _userLoginStatus.SetLogedInUser(logedInUser);
            TempData["Message"] = $"Welcome to Organizer {logedInUser.Name}!";
            return RedirectToPage("./Events");              
        }       
    }
}