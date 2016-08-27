using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentInputModel model)
        {

            if (model != null && ModelState.IsValid)
            {
                var e = new Comment()
                {
                    Author = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name),
                    Text = model.Text,
                    Date = model.Date

                };


                db.Comments.Add(e);
                db.SaveChanges();
                this.AddNotification("Comment created", NotificationType.INFO);
                return RedirectToAction("Create");
            }
            return View(model);
        }

    }
}