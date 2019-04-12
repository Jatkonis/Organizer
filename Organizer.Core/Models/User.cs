using System.Collections.Generic;

namespace Organizer.Core.Models
{
    public class User
    {
        public int UserId { get; set; }        
        public string Login { get; set; }
        public string Password { get; set; }        
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Event> Events { get; set; } // needed for database migration
    }
}
