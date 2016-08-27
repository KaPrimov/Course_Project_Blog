using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Course_Project_Blog.Models
{
    public class Class1
    {
        public int Id { get; set; }
        public string Teams { get; set; }
        public DateTime StarTime { get; set; }
        public string Result { get; set; }
        public string Author { get; set; }

        public static Expression<Func<Game, GameDetailsViewModel>> ViewModel
        {
            get
            {
                return g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Result = g.Result,
                    Author = g.Author.Id
                };
            }
        }
    }
}