using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course_Project_Blog.Extensions;
using Course_Project_Blog.Models;

namespace Course_Project_Blog.Controllers
{
    public class TagsController : BaseController
    {
        public ActionResult Create()
        {
            PopulatePostsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "TagId,Title")]Tag tag)
        {

            if (ModelState.IsValid)
            {
                tag.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                db.Tags.Add(tag);
                db.SaveChanges();
                this.AddNotification("Tag created", NotificationType.INFO);
                return RedirectToAction("Create");
            }
            PopulatePostsDropDownList(tag.PostId);
            return View(tag);

        }
       
        private void PopulatePostsDropDownList(object selectedPost = null)
        {
            var postsQuery = from p in db.Posts
                             orderby p.Title
                             select p;
            ViewBag.PostId = new SelectList(postsQuery, "PostId", "Title", selectedPost);
        }
       
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                this.AddNotification("The Tag can not be found", NotificationType.ERROR);
                return RedirectToAction("Index", "Posts");
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                this.AddNotification("The Tag can not be found", NotificationType.ERROR);
                return RedirectToAction("Index", "Posts");
            }
            return View(tag);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
            db.SaveChanges();
            this.AddNotification("Tag deleated.", NotificationType.INFO);
            return RedirectToAction("Index", "Posts");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}