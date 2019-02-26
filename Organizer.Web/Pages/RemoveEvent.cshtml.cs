using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Pages
{
    public class RemoveEventModel : PageModel
    {
           
        public EventViewModel Event { get; set; }        

        private readonly IEventData eventData;

        public RemoveEventModel(IEventData eventData)
        {
            this.eventData = eventData;
        }
        public IActionResult OnGet(int eventId)
        {
            Event = eventData.GetById(eventId);
            if (Event == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int eventId)
        {            
            var eventt = eventData.Remove(eventId);
            TempData["Message"] = "Event was deleted";
            return RedirectToPage("./Events");
        }
    }
}