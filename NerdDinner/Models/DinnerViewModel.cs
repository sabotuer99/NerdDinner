using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Model;

namespace NerdDinner.Controllers
{
    public class JsonDinner
    {
        public JsonDinner() { }
        public JsonDinner(Dinner dinner)
        {
            DinnerId = dinner.DinnerId;
            EventDate = dinner.EventDate.ToString();
            Latitude = dinner.Latitude;
            Longitude = dinner.Longitude;
            Title = dinner.Title;
            Description = dinner.Description;
            RSVPCount = dinner.RSVPs.Count;
            Url = "dinner/details/" + dinner.DinnerId.ToString();

        }

        public int DinnerId { get; set; }
        public string EventDate { get; set; }
        public string Title { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Description { get; set; }
        public int RSVPCount { get; set; }
        public string Url { get; set; }
    }


    public class DinnerViewModel
    {
        public static IList<JsonDinner> GetJsonDinners(IEnumerable<Dinner> dinners)
        {
            var result = new List<JsonDinner>();
            dinners.ToList().ForEach(x => result.Add(new JsonDinner(x)));
            return result;
        }

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