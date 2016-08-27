using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course_Project_Blog.Models
{
    public class Game
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Teams { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StarTime { get; set; }

        public ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public string Result { get; set; }
    }
}