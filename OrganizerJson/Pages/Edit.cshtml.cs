using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using static OrganizerJson.Event;

namespace OrganizerJson.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Event Event { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }

        private readonly IEventData eventData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IEventData eventData, IHtmlHelper htmlHelper)
        {
            this.eventData = eventData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? eventId)
        {
            Priorities = htmlHelper.GetEnumSelectList<PriorityType>();
            if (eventId.HasValue)
            {
                Event = eventData.GetById(eventId.Value);
            }
            else
            {
                Event = new Event();
            }
            
            if (Event == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Priorities = htmlHelper.GetEnumSelectList<PriorityType>();
                return Page();

            }
            if (Event.Id > 0)
            {
                eventData.Update(Event);
            }
            else
            {
                eventData.Add(Event);
            }
            TempData["Message"] = "Events saved!";
            return RedirectToPage("./Details", new { eventId = Event.Id });    
        }
    }
}