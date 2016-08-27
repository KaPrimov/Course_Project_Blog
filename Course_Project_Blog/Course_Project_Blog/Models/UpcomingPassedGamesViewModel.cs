using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_Project_Blog.Models
{
    public class UpcomingPassedGamesViewModel
    {
        public IEnumerable<GamesViewModel> UpcomingGames { get; set; }
        public IEnumerable<GamesViewModel> PassedEvents { get; set; }
    }
}