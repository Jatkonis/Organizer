using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Organizer.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Welcome to Organizer";
        }
    }
}