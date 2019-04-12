using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        private readonly IUserRepository _userRepository;
        private readonly IUserLoginStatusService _userLoginStatusService;

        public SignUpModel(IUserRepository userRepository, IUserLoginStatusService userLoginStatusService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); ;
            _userLoginStatusService = userLoginStatusService ?? throw new ArgumentNullException(nameof(userLoginStatusService)); ;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userNoViewModel = UserMapper.MapFromViewModelUser(User);
            _userRepository.AddUser(userNoViewModel);
            _userLoginStatusService.SetLoggedInUser(userNoViewModel);

            TempData["Message"] = $"Welcome to Organizer {userNoViewModel.Name}! Create your first Event!";
            return RedirectToPage("./Events");
        }
    }
}