using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finalproject.Context;
using finalproject.Models;

namespace finalproject.Controllers
{
    public class LigneCommandesController : Controller
    {
        private CtxDB db = new CtxDB();

        // GET: LigneCommandes
        public ActionResult Index()
        {
            return View(db.LignesCmd.ToList());
        }

        // GET: LigneCommandes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.LignesCmd.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LigneCommandes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numLigne")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.LignesCmd.Add(ligneCommande);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ligneCommande);
        }

        // GET: LigneCommandes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.LignesCmd.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numLigne")] LigneCommande ligneCommande)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligneCommande).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ligneCommande);
        }

        // GET: LigneCommandes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LigneCommande ligneCommande = db.LignesCmd.Find(id);
            if (ligneCommande == null)
            {
                return HttpNotFound();
            }
            return View(ligneCommande);
        }

        // POST: LigneCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LigneCommande ligneCommande = db.LignesCmd.Find(id);
            db.LignesCmd.Remove(ligneCommande);
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
