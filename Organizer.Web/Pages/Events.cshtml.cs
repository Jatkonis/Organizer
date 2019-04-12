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
        private readonly IUserLoginStatusService _userLoginStatusService;

        public EventsModel(IEventStore eventStore, IUserLoginStatusService userLoginStatusService)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore)); ;
            _userLoginStatusService = userLoginStatusService ?? throw new ArgumentNullException(nameof(userLoginStatusService)); ;
        }

        public void OnGet()
        {
            var userId = _userLoginStatusService.GetLoggedInUserId();
            var filteredEventsById = _eventStore.GetByDescriptionForUser(SearchTerm, userId);

            var result = filteredEventsById
                .Select(@event => EventMapper.MapToViewModel(@event))
                .ToList();

            Events = result;
        }
    }
}