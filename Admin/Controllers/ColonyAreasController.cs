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
    [Authorize]
    public class ColonyAreasController : Controller
    {
        private DbModel db = new DbModel();

        // GET: ColonyAreas
        public ActionResult Index()
        {
            var colonyAreas = db.ColonyAreas.Include(c => c.CityArea);
            return View(colonyAreas.ToList());
        }

        // GET: ColonyAreas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColonyArea colonyArea = db.ColonyAreas.Find(id);
            if (colonyArea == null)
            {
                return HttpNotFound();
            }
            return View(colonyArea);
        }

        // GET: ColonyAreas/Create
        public ActionResult Create()
        {
            ViewBag.CityAreaId = new SelectList(db.CityAreas, "Id", "Name");
            return View();
        }

        // POST: ColonyAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CityAreaId")] ColonyArea colonyArea)
        {
            if (ModelState.IsValid)
            {
                db.ColonyAreas.Add(colonyArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityAreaId = new SelectList(db.CityAreas, "Id", "Name", colonyArea.CityAreaId);
            return View(colonyArea);
        }

        // GET: ColonyAreas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColonyArea colonyArea = db.ColonyAreas.Find(id);
            if (colonyArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityAreaId = new SelectList(db.CityAreas, "Id", "Name", colonyArea.CityAreaId);
            return View(colonyArea);
        }

        // POST: ColonyAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CityAreaId")] ColonyArea colonyArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colonyArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityAreaId = new SelectList(db.CityAreas, "Id", "Name", colonyArea.CityAreaId);
            return View(colonyArea);
        }

        // GET: ColonyAreas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColonyArea colonyArea = db.ColonyAreas.Find(id);
            if (colonyArea == null)
            {
                return HttpNotFound();
            }
            return View(colonyArea);
        }

        // POST: ColonyAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ColonyArea colonyArea = db.ColonyAreas.Find(id);
            db.ColonyAreas.Remove(colonyArea);
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
