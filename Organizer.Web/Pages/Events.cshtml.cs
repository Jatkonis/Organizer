using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Pages
{
    public class EventsModel : PageModel
    {
        public IEnumerable<EventViewModel> Events { get; set; }
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