using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Models;
using Organizer.Core.Services;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;
using System;

namespace Organizer.Web.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public new UserViewModel User { get; set; }

        private readonly IUserRepositories _userRepositories;
        private readonly IUserLoginStatus _userLoginStatus;

        public SignUpModel(IUserRepositories userRepositories, IUserLoginStatus userLoginStatus)
        {
            _userRepositories = userRepositories ?? throw new ArgumentNullException(nameof(userRepositories)); ;
            _userLoginStatus = userLoginStatus ?? throw new ArgumentNullException(nameof(userLoginStatus)); ;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }            
            User userNoViewModel = UserMapper.MapFromViewModelUser(User);
            _userRepositories.AddUser(userNoViewModel);
            _userLoginStatus.SetLogedInUser(userNoViewModel);

            TempData["Message"] = $"Welcome to Organizer {userNoViewModel.Name}! Create your first Event!";
            return RedirectToPage("./Events");            
        }
    }
}