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
    public class CityAreasController : Controller
    {
        private DbModel db = new DbModel();

        // GET: CityAreas
        public ActionResult Index()
        {
            var cityAreas = db.CityAreas.Include(c => c.City);
            return View(cityAreas.ToList());
        }

        // GET: CityAreas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityArea cityArea = db.CityAreas.Find(id);
            if (cityArea == null)
            {
                return HttpNotFound();
            }
            return View(cityArea);
        }

        // GET: CityAreas/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        // POST: CityAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CityId")] CityArea cityArea)
        {
            if (ModelState.IsValid)
            {
                db.CityAreas.Add(cityArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", cityArea.CityId);
            return View(cityArea);
        }

        // GET: CityAreas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityArea cityArea = db.CityAreas.Find(id);
            if (cityArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", cityArea.CityId);
            return View(cityArea);
        }

        // POST: CityAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CityId")] CityArea cityArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", cityArea.CityId);
            return View(cityArea);
        }

        // GET: CityAreas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityArea cityArea = db.CityAreas.Find(id);
            if (cityArea == null)
            {
                return HttpNotFound();
            }
            return View(cityArea);
        }

        // POST: CityAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CityArea cityArea = db.CityAreas.Find(id);
            db.CityAreas.Remove(cityArea);
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
