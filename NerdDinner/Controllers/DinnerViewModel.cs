using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Model;

namespace NerdDinner.Controllers
{
    public class DinnerViewModel
    {
        public const int PageSize = 25;

        public Dinner SelectedDinner { get; set; }
        public int RSVPs { get; set; }
        string _currentUser;
        public string CurrentUser
        {
            get
            {
                if (String.IsNullOrEmpty(_currentUser))
                {
                    if (HttpContext.Current != null)
                        _currentUser = HttpContext.Current.User.Identity.Name;
                }
                return _currentUser;
            }

            set
            {
                _currentUser = value;
            }
        }

        public DateTime DatePrompt
        {
            get
            {
                return DateTime.Now.AddDays(7);
            }
        }

        public string TimePrompt
        {
            get
            {
                return "6:00pm";
            }
        }

        public bool IsCurrentUserOwner
        {
            get
            {
                return SelectedDinner.HostedBy.Equals(CurrentUser, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}