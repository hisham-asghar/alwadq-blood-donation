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
                return RedirectToAction("Index");
            }

            //var donars = db.Donars.Include(d => d.BloodGroup).Include(d => d.ColonyArea).Include(d => d.Gender).Include(d => d.MartialStatu);
            //var relationships = db.DonarRelationshipViews.


            return View(donar);
        }

        // GET: Donars/Create
        public ActionResult Create()
        {
            var users = db.DonarDetailViews.ToDictionary(d => d.DonarId, v => v.FirstName + " " + v.LastName);
            users[0] = "None";
            ViewBag.ReferedBy = new SelectList(users.OrderBy(k => k.Key).Select(k => new {Id = k.Key, Name = k.Value}), "Id", "Name");
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
        public ActionResult Create([Bind(Include = "DonarId,FirstName,LastName,MobilePhone,AlternateMobilePhone,EmailAddress,GenderId,MartialStatusId,BloodGroupId,Weight,StreetAddress,ColonyAreaId")] Donar donar,int age = 0,int ReferedBy = 0)
        {
            if (ModelState.IsValid)
            {
                if (donar.DateOfBirth == null && age > 0)
                {
                    donar.DateOfBirth = DateTime.Now.AddYears(-1 * age);
                }

                if (ReferedBy > 0)
                {
                    var newrefere = db.Donars.FirstOrDefault();
                    donar.Donars = new List<Donar>() { newrefere };
                }
                 //   donar.Donars.Add(db.Donars.Find(ReferedBy));
                donar.OnCreated = DateTime.Now;
                donar.OnModified = DateTime.Now;
                db.Donars.Add(donar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            var users = db.DonarDetailViews.ToDictionary(d => d.DonarId, v => v.FirstName + " " + v.LastName);
            users[0] = "None";
            ViewBag.ReferedBy = new SelectList(users.OrderBy(k => k.Key).Select(k => new { Id = k.Key, Name = k.Value }), "Id", "Name",ReferedBy);
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

            var referedBy = donar.Donars.FirstOrDefault();
            var users = db.DonarDetailViews.Where(d => d.DonarId != id).ToDictionary(d => d.DonarId, v => v.FirstName + " " + v.LastName);
            users[0] = "None";
            var referedById = referedBy?.DonarId ?? 0;
            ViewBag.ReferedBy = new SelectList(users.OrderBy(k => k.Key).Select(k => new {Id = k.Key, Name = k.Value}),
                "Id", "Name", referedById);
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
        public ActionResult Edit([Bind(Include = "DonarId,FirstName,LastName,MobilePhone,AlternateMobilePhone,EmailAddress,GenderId,MartialStatusId,BloodGroupId,Weight,StreetAddress,ColonyAreaId")] Donar donar,DateTime? DateOfBirth,int age = 0, int ReferedBy = 0)
        {
            if (ModelState.IsValid)
            {
                //var oldDonar = db.Donars.FirstOrDefault(d => d.DonarId == donar.DonarId);
                //if (oldDonar == null) return RedirectToAction("Index");
                if (DateOfBirth != null)
                {
                    donar.DateOfBirth = DateOfBirth;
                }
                else if (age > 0)
                {
                    donar.DateOfBirth = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-1 * age);
                }

                //if (ReferedBy > 0)
                //{
                //    var refere = donar.Donars.FirstOrDefault();
                //    var newrefere = db.Donars.FirstOrDefault(d => d.DonarId == ReferedBy);
                //    if (refere != null)
                //    {
                //        donar.Donars.Remove(refere);
                //        donar.Donars.Add(new Donar() { DonarId = ReferedBy });
                //    }
                //    else
                //    {
                //        donar.Donars = new List<Donar>() {new Donar() {DonarId = ReferedBy} };
                //    }
                //}

                //donar.OnModified = DateTime.Now;
                ////db.Entry(donar).Property(p => p.OnCreated).IsModified = false;
                //if (oldDonar != null) donar.OnCreated = oldDonar.OnCreated;
                //else
                donar.OnCreated = DateTime.Now;
                donar.OnModified = DateTime.Now;
                db.Entry(donar).State = EntityState.Modified;

                db.SaveChanges();
                if (ReferedBy > 0)
                    UpdateRefered(donar.DonarId, ReferedBy);
                return RedirectToAction("Details", "Donars", new { Id = donar.DonarId });
            }
            
            var users = db.DonarDetailViews.ToDictionary(d => d.DonarId, v => v.FirstName + " " + v.LastName);
            users[0] = "None";
            ViewBag.ReferedBy = new SelectList(users.OrderBy(k => k.Key).Select(k => new { Id = k.Key, Name = k.Value }), "Id", "Name",ReferedBy);
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "Id", "Name", donar.BloodGroupId);
            ViewBag.ColonyAreaId = new SelectList(db.ColonyAreaViews.Select(c => new {
                Id = c.ColonyAreaId,
                Name = c.ColonyAreaName + ", " + c.CityAreaName + ", " + c.CityName + ", " + c.CountryName
            }), "Id", "Name");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", donar.GenderId);
            ViewBag.MartialStatusId = new SelectList(db.MartialStatus, "Id", "Name", donar.MartialStatusId);
            return View(donar);
        }

        private void UpdateRefered(long donarDonarId, int referedBy)
        {
            using (var ddb = new DbModel())
            {
                var query =
                    $"Delete from dbo.DonarRelationships where RelatedPersonId = {donarDonarId}; INSERT INTO [dbo].[DonarRelationships] ([PersonId],[RelatedPersonId]) VALUES ({referedBy},{donarDonarId})";
                ddb.Database.ExecuteSqlCommand(query);
            }
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
