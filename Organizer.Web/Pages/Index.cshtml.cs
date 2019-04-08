using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using System;

namespace Organizer.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserLoginStatus _userLoginStatus;

        public string HelloUrl { get; set; }
        public string Message { get; set; }

        public IndexModel(IUserLoginStatus userLoginStatus)
        {
            _userLoginStatus = userLoginStatus ?? throw new ArgumentNullException(nameof(userLoginStatus)); ;
        }

        public void OnGet()
        {            
            Message = "Welcome to Organizer";           
        }
    }
}
