using Organizer.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Core.Services
{
    public interface IUserLoginStatus
    {
        void SetLogedInUser(User user);
        int GetLogedInUserId();
        void LogOut();
    }
}
