using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Course_Project_Blog.Extensions;
using Course_Project_Blog.Models;
using Microsoft.AspNet.Identity;

namespace Course_Project_Blog.Controllers
{
    public class GamesController : BaseController
    {
        
        public ActionResult Index()
        {
            var games = db.Games.OrderBy(g => g.StarTime).Select(g => new GamesViewModel()
            {
                Id = g.Id,
                Teams = g.Teams,
                StarTime = g.StarTime,
               
            });
            var upcomingGames = games.Where(g => g.StarTime > DateTime.Now);
            var passedGames = games.Where(g => g.StarTime <= DateTime.Now);
            return View(new UpcomingPassedGamesViewModel()
            {
                UpcomingGames = upcomingGames,
                PassedEvents = passedGames
            });

            
        }

        //GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(GamesInputModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var g = new Game()
                {
                    AuthorId = User.Identity.GetUserId(),
                    Teams = model.Teams,
                    StarTime = model.StarTime,
                    Result = model.Result
                };
                db.Games.Add(g);
                db.SaveChanges();
                this.AddNotification("Game added", NotificationType.INFO);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gameToEdit = LoadGame(id);
            if (gameToEdit == null)
            {
                this.AddNotification("Cannoit edit event #" + id, NotificationType.ERROR);
                return RedirectToAction("Index");

            }
            var model = GamesInputModel.CreateFromGame(gameToEdit);
            return View(model);
        }

        private Game LoadGame(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var gameToEdit = db.Games.Where(g => g.Id == id).FirstOrDefault(g => g.AuthorId == currentUserId || isAdmin());
            return gameToEdit;
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(int id, GamesInputModel model)
        {
            var gameToEdit = LoadGame(id);
            if (gameToEdit == null)
            {
                this.AddNotification("Cannoit edit event #" + id, NotificationType.ERROR);
                return RedirectToAction("Index");
            }

            if (ModelState != null && ModelState.IsValid)
            {
                gameToEdit.Teams = model.Teams;
                gameToEdit.StarTime = model.StarTime;
                gameToEdit.Result = model.Result;

                db.SaveChanges();
                this.AddNotification("Event edited", NotificationType.INFO);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult GamesDetailsById(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            var isAdmin = this.isAdmin();
            var gameDetails = db.Games.Where(g => g.Id == id)
                .Where(g => isAdmin || (g.AuthorId != null && g.AuthorId == currentUserId))
                .Select(GameDetailsViewModel.ViewModel)
                .FirstOrDefault();
            var isOwner = (gameDetails != null && gameDetails.Author != null && gameDetails.Author == currentUserId);
            this.ViewBag.CanEdit = isOwner || isAdmin;
            return this.PartialView("_GamesDetails", gameDetails);
        }
    }
}