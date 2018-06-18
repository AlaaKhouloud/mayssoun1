using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using finalproject.Context;
using finalproject.Models;

namespace finalproject.Controllers
{
   
    public class ArticlesController : Controller
    {
        private CtxDB db = new CtxDB();

        // GET: Articles
        public ActionResult Index()
        { 
            return View(db.Articles.ToList());
        }

        public ActionResult CreateBar()
        {
            string[] xv = new string[db.Articles.Count()];
            string[] yv = new string[db.Articles.Count()];
            int i = 0;
            foreach (var item in db.Articles.ToArray())
            {
                xv[i] = item.designation;
                yv[i] = item.stock.ToString();
                i++;
            }
            //Create bar chart
            var chart = new Chart(width: 300, height: 200)
            .AddSeries(chartType: "bar",
                             xValue: xv, yValues: yv).Write("png");
            return null;
        }

        public ActionResult CreatePie()
        {
            string[] xv = new string[db.Articles.Count()];
            string[] yv = new string[db.Articles.Count()];
            int i = 0;
            foreach (var item in db.Articles.ToArray())
            {
                xv[i] = item.designation;
                yv[i] = item.stock.ToString();
                i++;
            }
            //Create bar chart
            var chart = new Chart(width: 300, height: 200)
            .AddSeries(chartType: "pie",
                             xValue: xv, yValues: yv).Write("png");
            return null;
        }

        public ActionResult CreateLine()
        {
            string[] xv = new string[db.Articles.Count()];
            string[] yv = new string[db.Articles.Count()];
            int i = 0;
            foreach (var item in db.Articles.ToArray())
            {
                xv[i] = item.designation;
                yv[i] = item.stock.ToString();
                i++;
            }
            //Create bar chart
            var chart = new Chart(width: 600, height: 200)
            .AddSeries(chartType: "line",
                             xValue: xv, yValues: yv).Write("png");
            return null;
        }


        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            var listcat = db.Categories.ToList();
            ViewBag.e = new SelectList(listcat, "refCat", "nomcatg");
            return View();
        }

        // POST: Articles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numArticle,designation,prixU,stock,photo")] Article article)
        {
            if (ModelState.IsValid)
            {
                string name = Request.Form["listecat"].ToString();
                // TempData["msg"] = "<script>alert('"+name+"');</script>";

                article.refcategorie =  name;

                article.categorie = ViewBag.e;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            var listcat = db.Categories.ToList();
            ViewBag.e = new SelectList(listcat, "refCat", "nomcatg");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numArticle,designation,prixU,stock,photo")] Article article)
        {
            if (ModelState.IsValid)
            {
                string name = Request.Form["listecat"].ToString();
                // TempData["msg"] = "<script>alert('"+name+"');</script>";

                article.refcategorie = name;

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
