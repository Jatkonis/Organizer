using Organizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Core.Services
{
    public interface IUserAuthentication
    {
        User GetUser(string login, string password);
    }
}
