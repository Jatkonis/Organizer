using System;
using System.Collections.Generic;
using System.Linq;
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

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        private readonly IEventStore _eventStore;
        private readonly IUserLoginStatus _userLoginStatus;

        public EventsModel(IEventStore eventStore, IUserLoginStatus userLoginStatus)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore)); ;
            _userLoginStatus = userLoginStatus ?? throw new ArgumentNullException(nameof(userLoginStatus)); ;
        }

        public void OnGet()
        {
            int userId = _userLoginStatus.GetLogedInUserId();
            var eventsFromStore = _eventStore.GetEventByDescription(SearchTerm);
            var sortedEventsById = eventsFromStore.Where(x => x.UserId == userId);          

            var result = new List<EventViewModel>();
            foreach (var @event in sortedEventsById)
            {
                result.Add(EventMapper.MapToViewModel(@event));
            }
            Events = result;
        }
    }
}