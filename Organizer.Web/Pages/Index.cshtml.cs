using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Organizer.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string HelloUrl { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Welcome to Organizer";
            HelloUrl = "https://i.redd.it/50mx8dvaxst01.png";
        }
    }
}
