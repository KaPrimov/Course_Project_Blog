using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Course_Project_Blog.Models
{
    public class CommentsViewModel
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Comment, CommentsViewModel>> ViewModel
        {
            get
            {
                return c => new CommentsViewModel()
                {
                    Text = c.Text,
                    Author = c.Author.FullName
                };
            }
        }
    }
}