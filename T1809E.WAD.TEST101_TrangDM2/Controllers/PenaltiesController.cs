using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1809E.WAD.TEST101_TrangDM2.Models;

namespace T1809E.WAD.TEST101_TrangDM2.Controllers
{
    public class PenaltiesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Penalties
        public ActionResult Index()
        {
          int pushUp = db.Penalties.Where(t => t.Method == 0).Sum(p => p.Amount);
          int money = db.Penalties.Where(t => t.Method != 0).Sum(p => p.Amount);
          ViewBag.PushUp = pushUp;
          ViewBag.Money = money;
            return View(db.Penalties.ToList());
        }

        // GET: Penalties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            return View(penalty);
        }

        // GET: Penalties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Penalties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,Method,Amount,DateTime")] Penalty penalty)
        {
          penalty.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Penalties.Add(penalty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(penalty);
        }

        // GET: Penalties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            return View(penalty);
        }

        // POST: Penalties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,Method,Amount,DateTime")] Penalty penalty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penalty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(penalty);
        }

        // GET: Penalties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penalty penalty = db.Penalties.Find(id);
            if (penalty == null)
            {
                return HttpNotFound();
            }
            return View(penalty);
        }

        // POST: Penalties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Penalty penalty = db.Penalties.Find(id);
            db.Penalties.Remove(penalty);
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
