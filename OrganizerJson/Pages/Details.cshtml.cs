using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrganizerJson.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IEventData eventData;

        public Event Event { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IEventData eventData)
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
    }
}