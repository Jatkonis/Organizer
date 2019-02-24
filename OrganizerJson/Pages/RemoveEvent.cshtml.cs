using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrganizerJson.Pages
{
    public class RemoveEventModel : PageModel
    {
           
        public Event Event { get; set; }        

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