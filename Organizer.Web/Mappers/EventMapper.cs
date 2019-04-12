using System;
using Organizer.Core.Models;
using Organizer.Web.ViewModels;

namespace Organizer.Web.Mappers
{
    public class EventMapper
    {
        public static Event MapFromViewModel(EventViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            return new Event()
            {
                EventId = viewModel.Id,
                ShortDescription = viewModel.ShortDescription,
                LongDescription = viewModel.LongDescription,
                Priority = viewModel.Priority,
                Date = viewModel.Date,
                UserId = viewModel.UserId
            };
        }

        public static EventViewModel MapToViewModel(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            return new EventViewModel()
            {
                Id = @event.EventId,
                ShortDescription = @event.ShortDescription,
                LongDescription = @event.LongDescription,
                Priority = @event.Priority,
                Date = @event.Date,
                UserId = @event.UserId
            };
        }
    }
}
