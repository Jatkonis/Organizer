using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Organizer.Core.Services;
using Organizer.Web.Mappers;
using Organizer.Web.ViewModels;
using System;

namespace Organizer.Web.Pages
{
    public class RemoveEventModel : PageModel
    {
        private readonly IEventStore _eventStore;           
        public EventViewModel Event { get; set; }

        public RemoveEventModel(IEventStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }
       
        public IActionResult OnGet(int eventId)
        {
            var eventFromStore = _eventStore.GetById(eventId);
            Event = EventMapper.MapToViewModel(eventFromStore);
            if (Event == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int eventId)
        {            
            _eventStore.Remove(eventId);
            TempData["Message"] = "Event was deleted";
            return RedirectToPage("./Events");
        }
    }
}