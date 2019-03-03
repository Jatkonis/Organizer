using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using Organizer.Web.Mappers;
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

        private readonly IEventStore _eventStore;

        public EventsModel(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void OnGet()
        {
            var eventsFromStore = _eventStore.GetEventByDescription(SearchTerm);
            var result = new List<EventViewModel>();
            foreach (var @event in eventsFromStore)
            {
                result.Add(EventMapper.MapToViewModel(@event));
            }
            Events = result;
        }
    }
}