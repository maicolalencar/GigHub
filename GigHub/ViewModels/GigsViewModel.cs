using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    public class GigsViewModel
    {
        public GigsViewModel()
        {
        }

        public IEnumerable<Gig> upcomingGigs { get; set; }
        public bool showActions { get; set; }
        public string Heading { get; internal set; }
    }
}