using System.ComponentModel.DataAnnotations;

namespace Organizer.Web.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Login name is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Login name should have more then 4 but less then 20 chars.")]
        public string Login { get; set; }
                
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Password should have more then 4 but less then 30 chars.")]
        public string Password { get; set; }
                
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Name should have more then 2 but less then 30 chars.")]
        public string Name { get; set; }
                
        [Required(ErrorMessage = "Surename is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Surname should have more then 2 but less then 30 chars.")]
        public string Surename { get; set; }
        
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
