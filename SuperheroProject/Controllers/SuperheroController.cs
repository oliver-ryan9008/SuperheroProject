using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroProject.Models;
using System.Data.Entity;

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
                              where h.SuperheroId == Id
                              select h).FirstOrDefault();
            return View(deleteHero);
        }

        [HttpPost, ActionName("Delete")]
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

        public ActionResult Update(Superhero superhero)
        {
            return View();
        }


        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSuperhero(int id)
        {
            //start here 7/25/18
            return View(id);
        }
    }
}