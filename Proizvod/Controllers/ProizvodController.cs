using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proizvod.Model;
using Proizvod.Persistance;

namespace Proizvod.Controllers
{
    public class ProizvodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Proizvodi.ToList());
        }

        public ActionResult Prikaz(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.Proizvodi.Find(id);
            if (proizvodModel == null)
            {
                return HttpNotFound();
            }
            return View(proizvodModel);
        }

        public ActionResult Kreiraj()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kreiraj([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] ProizvodModel proizvodModel)
        {
            if (ModelState.IsValid)
            {
                db.Proizvodi.Add(proizvodModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proizvodModel);
        }

  
        public ActionResult Izmena(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.Proizvodi.Find(id);
            if (proizvodModel == null)
            {
                return HttpNotFound();
            }
            return View(proizvodModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Izmena([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] ProizvodModel proizvodModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proizvodModel);
        }

        public ActionResult Brisanje(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.Proizvodi.Find(id);
            if (proizvodModel == null)
            {
                return HttpNotFound();
            }
            return View(proizvodModel);
        }

        [HttpPost, ActionName("Brisanje")]
        [ValidateAntiForgeryToken]
        public ActionResult PotvrdiBrisanje(int id)
        {
            ProizvodModel proizvodModel = db.Proizvodi.Find(id);
            db.Proizvodi.Remove(proizvodModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
