using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dollybal;
using dollybal.Repository;

namespace dolly.Controllers
{
    public class DollySheepController : Controller
    {
        ISheepKeeper db;
        public DollySheepController(ISheepKeeper keeper)
        {
            db = keeper;
        }

        // GET: DollySheep
        public ActionResult Index()
        {
            return View(db.GetSheeps());
        }

        // GET: DollySheep/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DollySheep dollySheep = db.GetSheep(id);
            if (dollySheep == null)
            {
                return HttpNotFound();
            }
            return View(dollySheep);
        }

        // GET: DollySheep/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DollySheep/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Height,DOB")] DollySheep dollySheep)
        {
            if (ModelState.IsValid)
            {
                db.AddSheep(dollySheep);
                return RedirectToAction("Index");
            }

            return View(dollySheep);
        }

        // GET: DollySheep/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DollySheep dollySheep = db.GetSheep(id);
            if (dollySheep == null)
            {
                return HttpNotFound();
            }
            return View(dollySheep);
        }

        // POST: DollySheep/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Height,DOB")] DollySheep dollySheep)
        {
            if (ModelState.IsValid)
            {
                db.UpdateSheep(dollySheep);
                return RedirectToAction("Index");
            }
            return View(dollySheep);
        }

        // GET: DollySheep/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DollySheep dollySheep = db.GetSheep(id);
            if (dollySheep == null)
            {
                return HttpNotFound();
            }
            return View(dollySheep);
        }

        // POST: DollySheep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DollySheep dollySheep = db.GetSheep(id);
            db.DeleteSheep(dollySheep);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
