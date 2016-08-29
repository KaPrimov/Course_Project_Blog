using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Course_Project_Blog.Extensions;
using Course_Project_Blog.Models;
using Microsoft.AspNet.Identity;


namespace Course_Project_Blog.Controllers
{
    public class CommentsController : BaseController
    {
        // GET: Comments/Create

        public ActionResult Create()
        {
            PopulatePostsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Text,PostId")]Comment comment)
        {
            
                if (ModelState.IsValid)
                {
                    comment.Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    this.AddNotification("Comment created", NotificationType.INFO);
                    return RedirectToAction("Create");
                }
            PopulatePostsDropDownList(comment.PostId);
            return View(comment);

            }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            PopulatePostsDropDownList(comment.PostId);
            return View(comment);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditComment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var commentToUpdate = db.Comments.Find(id);
            if (TryUpdateModel(commentToUpdate, "",
               new string[] { "Text", "PostId" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Create");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulatePostsDropDownList(commentToUpdate.PostId);
            return View(commentToUpdate);
        }

        private void PopulatePostsDropDownList(object selectedPost = null)
        {
            var postsQuery = from p in db.Posts
                                   orderby p.Title
                                   select p;
            ViewBag.PostId = new SelectList(postsQuery, "PostId", "Title", selectedPost);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                this.AddNotification("The Post can not be found", NotificationType.ERROR);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

    }
}
