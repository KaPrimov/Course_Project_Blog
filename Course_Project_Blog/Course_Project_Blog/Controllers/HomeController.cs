using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Course_Project_Blog.Models;
using System.Data.Entity;
using System.Web.Providers.Entities;

namespace Course_Project_Blog.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(5);
            var sidePosts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(5);

            this.ViewBag.sidePosts = sidePosts;

            return View(posts.ToList());
            
        }

        public ActionResult Schedule()
        {
            List<string> items = (List<string>) this.Session["items"] ?? new List<string>();

            return View(items);
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddItem(string newItem)
        {
            List<string> items = (List<string>)this.Session["items"] ?? new List<string>();
            items.Add(newItem);
            this.Session["items"] = items;

            return this.RedirectToAction("Schedule");
        }


        [Authorize(Roles = "Administrators")]
        public ActionResult RemoveItem(int index)
        {
            List<string> items = (List<string>)this.Session["items"];

            if (items != null && index < items.Count)
            {
                items.RemoveAt(index);
                this.Session["items"] = items;
            }

            return this.RedirectToAction("Schedule");
        }

        public ActionResult MyAudio()
        {
            var file = Server.MapPath("~/app_data/test.mp3");
            return File(file, "audio/mp3");
        }
    }
}