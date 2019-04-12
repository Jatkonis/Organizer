using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;
using System;

namespace Organizer.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IEventStore _eventStore;

        public EventViewModel Event { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailsModel(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore)); ;
        }

        public IActionResult OnGet(int eventId)
        {
            var eventFromStore = _eventStore.GetById(eventId);
            if (eventFromStore == null)
            {
                return RedirectToPage("./NotFound");
            }

            Event = EventMapper.MapToViewModel(eventFromStore);
            return Page();
        }
    }
}