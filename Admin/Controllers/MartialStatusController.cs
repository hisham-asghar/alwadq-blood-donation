using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LayerDb;

namespace Admin.Controllers
{
    public class MartialStatusController : Controller
    {
        private DbModel db = new DbModel();

        // GET: MartialStatus
        public ActionResult Index()
        {
            return View(db.MartialStatus.ToList());
        }

        // GET: MartialStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialStatu martialStatu = db.MartialStatus.Find(id);
            if (martialStatu == null)
            {
                return HttpNotFound();
            }
            return View(martialStatu);
        }

        // GET: MartialStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MartialStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MartialStatu martialStatu)
        {
            if (ModelState.IsValid)
            {
                db.MartialStatus.Add(martialStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(martialStatu);
        }

        // GET: MartialStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialStatu martialStatu = db.MartialStatus.Find(id);
            if (martialStatu == null)
            {
                return HttpNotFound();
            }
            return View(martialStatu);
        }

        // POST: MartialStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MartialStatu martialStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(martialStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(martialStatu);
        }

        // GET: MartialStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MartialStatu martialStatu = db.MartialStatus.Find(id);
            if (martialStatu == null)
            {
                return HttpNotFound();
            }
            return View(martialStatu);
        }

        // POST: MartialStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MartialStatu martialStatu = db.MartialStatus.Find(id);
            db.MartialStatus.Remove(martialStatu);
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
