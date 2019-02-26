using System;
using System.ComponentModel.DataAnnotations;
using Organizer.Core.Models;

namespace Organizer.Web.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string ShortDescription { get; set; }
        [StringLength(250)]
        public string LongDescription { get; set; }
        public PriorityType Priority { get; set; }
    }
}
