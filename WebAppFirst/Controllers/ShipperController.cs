using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace WebAppFirst.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper

        NorthwindOriginalEntities1 db = new NorthwindOriginalEntities1();
        public ActionResult Index()
        {
            List<Shippers> model = db.Shippers.ToList();
            return View(model);
            //var shippers = db.Shippers.Include(s => s.Region); 

            //return View(shippers.ToList());
        }


        #region Lisätään kontrolleriin tietojen muokkaus (Update)
        //kopioitu 4. päivän materiaalista:


        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null) return HttpNotFound();
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
            return View(shippers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Katso https://go.microsoft.com/fwlink/?LinkId=317598

        public ActionResult Edit([Bind(Include = "ShipperID,CompanyName,Phone,RegionID")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippers).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
                return RedirectToAction("Index");
            }
            return View(shippers);
        }
        #endregion


        #region Lisätään kontrolleriin tiedon lisäys (Create)  // huom. muista että hiiren kakkosella pitää tehdä > Add view, jotta saadaan Shipper-kansioon cshtml-tiedosto!

        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,CompanyName,Phone,RegionID")] Shippers shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
                return RedirectToAction("Index");
            }
            return View(shipper);
        }
        #endregion


        #region Lisätään kontrolleriin tietojen poisto (Delete)

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null) return HttpNotFound();
            return View(shippers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            db.Shippers.Remove(shippers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}