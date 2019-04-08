using System;
using System.ComponentModel.DataAnnotations;
using Organizer.Core.Models;

namespace Organizer.Web.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date field is required.")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Short Desciption field is required.")]
        [StringLength(50)]
        public string ShortDescription { get; set; }

        [StringLength(250)]
        public string LongDescription { get; set; }

        public PriorityType Priority { get; set; }
        public int UserId { get; set; }
    }
}
