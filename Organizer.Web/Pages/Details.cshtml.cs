using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IEventStore _eventData;

        public EventViewModel Event { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IEventStore eventData)
        {
            _eventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
        }
        public IActionResult OnGet(int eventId)
        {
            Event = _eventData.GetById(eventId);
            if (Event == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}