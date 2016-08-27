using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Course_Project_Blog.Models;
using Microsoft.AspNet.Identity;

namespace Course_Project_Blog.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public bool isAdmin()
        {
            var currenUserID = User.Identity.GetUserId();
            var isAdmin = (currenUserID != null && User.IsInRole("Administrators"));
            return isAdmin;
        }
    }
}