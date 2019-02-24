using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrganizerJson.Pages
{
    public class IndexModel : PageModel
    {
        public string HelloUrl { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Welcome to OrganizerJson";
            HelloUrl = "https://i.redd.it/50mx8dvaxst01.png";
        }
    }
}
