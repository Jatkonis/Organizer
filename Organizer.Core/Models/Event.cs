﻿using System;

namespace Organizer.Core.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public PriorityType Priority { get; set; }
        public int UserId { get; set; }
    }
}
