using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Organizer.Core.Models;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Mappers
{
    public class EventMapper
    {
        // TODO: convert to EXTENSION METHODS.
        public static Event MapFromViewModel(EventViewModel viewModel)
        {
            return new Event()
            {
                Id = viewModel.Id,
                ShortDescription = viewModel.ShortDescription,
                LongDescription = viewModel.LongDescription,
                Priority = viewModel.Priority,
                Date = viewModel.Date
            };
        }

        public static EventViewModel MapToViewModel(Event @event)
        {
            return new EventViewModel()
            {
                Id = @event.Id,
                ShortDescription = @event.ShortDescription,
                LongDescription = @event.LongDescription,
                Priority = @event.Priority,
                Date = @event.Date
            };
        }
    }
}
