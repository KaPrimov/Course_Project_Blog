using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Course_Project_Blog.Models;

namespace Course_Project_Blog.View_Models
{
    public class PostTagsViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<SelectListItem> AllTags { get; set; }

        private List<int> _selectTags;
    }
}