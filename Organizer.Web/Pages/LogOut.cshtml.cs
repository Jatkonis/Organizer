using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using System;

namespace Organizer.Web.Pages
{
    public class LogOutModel : PageModel
    {
        private readonly IUserLoginStatusService _userLoginStatusService;

        public LogOutModel(IUserLoginStatusService userLoginStatusService)
        {
            _userLoginStatusService = userLoginStatusService ?? throw new ArgumentNullException(nameof(userLoginStatusService));
        }

        public IActionResult OnPost()
        {
            _userLoginStatusService.LogOut();
            return RedirectToPage("./Index");
        }
    }
}