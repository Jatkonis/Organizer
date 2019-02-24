using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrganizerJson.Pages
{
    public class EventsModel : PageModel
    {
        public IEnumerable<Event> Events { get; set; }
        [TempData]
        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        private readonly IEventData eventData;

        public EventsModel(IEventData eventData)
        {
            this.eventData = eventData;
        }

        public void OnGet()
        {
            Events = eventData.GetEventByDescription(SearchTerm);
        }
    }
}