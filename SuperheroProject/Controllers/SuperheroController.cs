using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroProject.Models;

namespace SuperheroProject.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superhero
        public ActionResult Index()
        {
            return View(db.Superhero.ToList());
        }

        public ActionResult Create()
        {
            //ViewBag.SuperheroName = new SelectList(db.Superhero, "SuperheroName", "AlterEgo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuperheroName, AlterEgo, PrimaryAbility, SecondaryAbility, Catchphrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Superhero.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.superheroName = new SelectList(db.Superhero);
            return View(superhero);
        }

        public ActionResult Delete(int Id)
        {
            var deleteHero = (from h in db.Superhero
                                    where h.SuperheroId == Id select h).FirstOrDefault();
            return View(deleteHero);
        }

        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var deleteHero = (from h in db.Superhero where h.SuperheroId == superhero.SuperheroId select h).FirstOrDefault();
            Superhero superhero = db.Superhero.Find(id);
            if (ModelState.IsValid)
            {
                db.Superhero.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(superhero);
        }
    }
}