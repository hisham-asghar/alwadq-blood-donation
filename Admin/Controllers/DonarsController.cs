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
    public class DonarsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Donars
        public ActionResult Index()
        {
            var donars = db.Donars.Include(d => d.BloodGroup).Include(d => d.ColonyArea).Include(d => d.Gender).Include(d => d.MartialStatu);
            return View(donars.ToList());
        }

        // GET: Donars/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donar donar = db.Donars.Find(id);
            if (donar == null)
            {
                return HttpNotFound();
            }
            return View(donar);
        }

        // GET: Donars/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name");
            ViewBag.ColonyAreaId = new SelectList(db.ColonyAreaViews.Select(c => new {
                Id = c.ColonyAreaId,
                Name = c.ColonyAreaName + ", " + c.CityAreaName + ", " + c.CityName + ", " + c.CountryName
            }), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            ViewBag.MartialStatusId = new SelectList(db.MartialStatus, "Id", "Name");
            return View();
        }

        // POST: Donars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonarId,FirstName,LastName,MobilePhone,AlternateMobilePhone,EmailAddress,GenderId,MartialStatusId,BloodGroupId,Weight,Longitude,Latitude,StreetAddress,ColonyAreaId")] Donar donar)
        {
            if (ModelState.IsValid)
            {
                donar.OnCreated = DateTime.Now;
                donar.OnModified = DateTime.Now;
                db.Donars.Add(donar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", donar.BloodGroupId);
            ViewBag.ColonyAreaId = new SelectList(db.ColonyAreaViews.Select(c => new {
                Id = c.ColonyAreaId,
                Name = c.ColonyAreaName + ", " + c.CityAreaName + ", " + c.CityName + ", " + c.CountryName
            }), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", donar.GenderId);
            ViewBag.MartialStatusId = new SelectList(db.MartialStatus, "Id", "Name", donar.MartialStatusId);
            return View(donar);
        }

        // GET: Donars/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donar donar = db.Donars.Find(id);
            if (donar == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", donar.BloodGroupId);
            ViewBag.ColonyAreaId = new SelectList(db.ColonyAreaViews.Select(c => new {
                Id = c.ColonyAreaId,
                Name = c.ColonyAreaName + ", " + c.CityAreaName + ", " + c.CityName + ", " + c.CountryName
            }), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", donar.GenderId);
            ViewBag.MartialStatusId = new SelectList(db.MartialStatus, "Id", "Name", donar.MartialStatusId);
            return View(donar);
        }

        // POST: Donars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonarId,FirstName,LastName,MobilePhone,AlternateMobilePhone,EmailAddress,GenderId,MartialStatusId,BloodGroupId,Weight,Longitude,Latitude,StreetAddress,ColonyAreaId")] Donar donar)
        {
            if (ModelState.IsValid)
            {
                donar.OnModified = DateTime.Now;
                db.Entry(donar).Property(p => p.OnCreated).IsModified = false;
                db.Entry(donar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", donar.BloodGroupId);
            ViewBag.ColonyAreaId = new SelectList(db.ColonyAreaViews.Select(c => new {
                Id = c.ColonyAreaId,
                Name = c.ColonyAreaName + ", " + c.CityAreaName + ", " + c.CityName + ", " + c.CountryName
            }), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", donar.GenderId);
            ViewBag.MartialStatusId = new SelectList(db.MartialStatus, "Id", "Name", donar.MartialStatusId);
            return View(donar);
        }

        // GET: Donars/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donar donar = db.Donars.Find(id);
            if (donar == null)
            {
                return HttpNotFound();
            }
            return View(donar);
        }

        // POST: Donars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Donar donar = db.Donars.Find(id);
            db.Donars.Remove(donar);
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
