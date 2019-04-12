using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organizer.Core.Models;
using Organizer.Core.Services;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly IEventStore _eventStore;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IUserLoginStatusService _userLoginStatusService;

        [BindProperty]
        public EventViewModel Event { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }


        public EditModel(IEventStore eventStore, IHtmlHelper htmlHelper, IUserLoginStatusService userLoginStatusService)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _htmlHelper = htmlHelper ?? throw new ArgumentNullException(nameof(htmlHelper));
            _userLoginStatusService = userLoginStatusService ?? throw new ArgumentNullException(nameof(userLoginStatusService));
        }

        public IActionResult OnGet(int? eventId)
        {
            Priorities = _htmlHelper.GetEnumSelectList<PriorityType>();

            if (eventId.HasValue)
            {
                var eventFromStore = _eventStore.GetById(eventId.Value);
                if (eventFromStore == null)
                {
                    return RedirectToPage("./NotFound");
                }

                Event = EventMapper.MapToViewModel(eventFromStore);
            }
            else
            {
                Event = new EventViewModel();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Priorities = _htmlHelper.GetEnumSelectList<PriorityType>();
                return Page();
            }

            if (Event.Id > 0)
            {                
                _eventStore.Update(EventMapper.MapFromViewModel(Event));
            }
            else
            {
                Event.UserId = _userLoginStatusService.GetLoggedInUserId();
                _eventStore.Add(EventMapper.MapFromViewModel(Event));
            }

            TempData["Message"] = "Events saved!";
            return RedirectToPage("./Events", new { eventId = Event.Id });    
        }
    }
}