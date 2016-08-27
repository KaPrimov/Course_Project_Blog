using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;

namespace Course_Project_Blog.Models
{
    public class GamesInputModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Teams { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StarTime { get; set; }

        public virtual ApplicationUser Author { get; set; }


        public string Result { get; set; }

        public static GamesInputModel CreateFromGame(Game g)
        {
            return new GamesInputModel()
            {
                Teams = g.Teams,
                StarTime = g.StarTime,
                
            };
        }
    }
}