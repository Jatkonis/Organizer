using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using System;

namespace Organizer.Web.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly IUserLoginStatus _userLoginStatus;

        public LogOutModel(IUserLoginStatus userLoginStatus)
        {
            _userLoginStatus = userLoginStatus ?? throw new ArgumentNullException(nameof(userLoginStatus));
        }

        public IActionResult OnPost()
        {
            _userLoginStatus.LogOut();
            return RedirectToPage("./Index");
        }
    }
}