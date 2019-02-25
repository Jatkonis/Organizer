using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerJson
{
    // TODO: why partial?
    public partial class Event
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
