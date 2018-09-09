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
    public class AcceptorDetailsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: AcceptorDetails
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Donars");
            //var acceptorDetails = db.AcceptorDetails.Include(a => a.Donar).Include(a => a.Donar1);
            //return View(acceptorDetails.ToList());
        }

        // GET: AcceptorDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptorDetail acceptorDetail = db.AcceptorDetails.Find(id);
            if (acceptorDetail == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Details", "Donars", new {Id = acceptorDetail.Donar.DonarId});
            //return View(acceptorDetail);
        }

        // GET: AcceptorDetails/Create
        public ActionResult Create(int acceptorId = 0,int donarId = 0)
        {
            var donarsList = db.Donars.Include(a => a.ColonyArea).Include(a => a.ColonyArea.CityArea).Select(u => new
            {
                Id = u.DonarId,
                Value =
                    u.FirstName+" "+u.LastName + ", " + u.StreetAddress + ", " + u.ColonyArea.Name + ", " + u.ColonyArea.CityArea.Name
            }).ToList();
            ViewBag.DonatedBy = new SelectList(donarsList, "Id", "Value", donarId);
            ViewBag.DonatedTo = new SelectList(donarsList, "Id", "Value", acceptorId);
            return View();
        }

        // POST: AcceptorDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcceptorId,DonatedTo,DonatedBy,BleedDate")] AcceptorDetail acceptorDetail, int acceptorId = 0, int donarId = 0)
        {
            if (ModelState.IsValid)
            {
                acceptorDetail.OnCreated = DateTime.Now;
                acceptorDetail.OnModified = DateTime.Now;
                db.AcceptorDetails.Add(acceptorDetail);
                db.SaveChanges();

                return RedirectToAction("Details", "Donars", new { Id = acceptorDetail.Donar.DonarId });
                //return RedirectToAction("Index");
            }

            var donarsList = db.Donars.Include(a => a.ColonyArea).Include(a => a.ColonyArea.CityArea).Select(u => new
            {
                Id = u.DonarId,
                Value =
                    u.FirstName + " " + u.LastName + ", " + u.StreetAddress + ", " + u.ColonyArea.Name + ", " + u.ColonyArea.CityArea.Name
            }).ToList();
            ViewBag.DonatedBy = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedBy);
            ViewBag.DonatedTo = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedTo);
            return View(acceptorDetail);
        }

        // GET: AcceptorDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptorDetail acceptorDetail = db.AcceptorDetails.Find(id);
            if (acceptorDetail == null)
            {
                return HttpNotFound();
            }
            var donarsList = db.Donars.Select(u => new
            {
                Id = u.DonarId,
                Value =
                    $"{u.FirstName} {u.LastName}, {u.StreetAddress}, {u.ColonyArea.Name}, {u.ColonyArea.CityArea.Name}"
            }).ToList();
            ViewBag.DonatedBy = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedBy);
            ViewBag.DonatedTo = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedTo);
            return View(acceptorDetail);
        }

        // POST: AcceptorDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcceptorId,DonatedTo,DonatedBy,BleedDate")] AcceptorDetail acceptorDetail)
        {
            if (ModelState.IsValid)
            {
                acceptorDetail.OnModified = DateTime.Now;
                db.Entry(acceptorDetail).State = EntityState.Modified;
                db.Entry(acceptorDetail).Property(p => p.OnCreated).IsModified = false;
                db.SaveChanges();
                //return RedirectToAction("Index");

                return RedirectToAction("Details", "Donars", new { Id = acceptorDetail.Donar.DonarId });
            }
            var donarsList = db.Donars.Include(a => a.ColonyArea).Include(a => a.ColonyArea.CityArea).Select(u => new
            {
                Id = u.DonarId,
                Value =
                    u.FirstName + " " + u.LastName + ", " + u.StreetAddress + ", " + u.ColonyArea.Name + ", " + u.ColonyArea.CityArea.Name
            }).ToList();
            ViewBag.DonatedBy = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedBy);
            ViewBag.DonatedTo = new SelectList(donarsList, "Id", "Value", acceptorDetail.DonatedTo);

            return View(acceptorDetail);
        }

        // GET: AcceptorDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcceptorDetail acceptorDetail = db.AcceptorDetails.Find(id);
            if (acceptorDetail == null)
            {
                return HttpNotFound();
            }
            return View(acceptorDetail);
        }

        // POST: AcceptorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            AcceptorDetail acceptorDetail = db.AcceptorDetails.Find(id);
            if (acceptorDetail != null) db.AcceptorDetails.Remove(acceptorDetail);
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
