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

        [BindProperty]
        public EventViewModel Event { get; set; }
        public IEnumerable<SelectListItem> Priorities { get; set; }


        public EditModel(IEventStore eventStore, IHtmlHelper htmlHelper)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
            _htmlHelper = htmlHelper ?? throw new ArgumentNullException(nameof(htmlHelper));
        }
        public IActionResult OnGet(int? eventId)
        {
            Priorities = _htmlHelper.GetEnumSelectList<PriorityType>();
            if (eventId.HasValue)
            {
                var eventFromStore = _eventStore.GetById(eventId.Value);
                Event = EventMapper.MapToViewModel(eventFromStore);
            }
            else
            {
                Event = new EventViewModel();
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
                Priorities = _htmlHelper.GetEnumSelectList<PriorityType>();
                return Page();

            }
            if (Event.Id > 0)
            {
                _eventStore.Update(EventMapper.MapFromViewModel(Event));
            }
            else
            {
                _eventStore.Add(EventMapper.MapFromViewModel(Event));
            }
            TempData["Message"] = "Events saved!";
            return RedirectToPage("./Events", new { eventId = Event.Id });    
        }
    }
}