using NerdDinner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerdDinner.Models
{
    public class RsvpViewModel
    {
        public List<RSVP> RSVPs { get; set; }
        public int DinnerId { get; set; }
    }
}