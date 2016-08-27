using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course_Project_Blog.Models
{
    public class CommentInputModel
    {
        public CommentInputModel()
        {
            this.Date = DateTime.Now;
        }

        public string Author_Id { get; set; }

        [ForeignKey("Author_Id")]
        public ApplicationUser Author { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        public int PostId { get; set; }

        [Required]
        public virtual Post Post { get; set; }


    }
}