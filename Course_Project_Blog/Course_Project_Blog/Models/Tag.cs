using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course_Project_Blog.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Title { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}