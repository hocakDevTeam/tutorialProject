using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorialProject.DataAccess;
using TutorialProject.Models;

namespace TutorialProject.Controllers
{
    public class ActivityLogsController : Controller
    {
        private WhatEver db = new WhatEver();

        // GET: ActivityLogs
        public ActionResult Index()
        {
            return View(db.ActivityLogs.ToList());
        }

        // GET: ActivityLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // GET: ActivityLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Action,CreatedBy,CreatedOn")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                db.ActivityLogs.Add(activityLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityLog);
        }

        // GET: ActivityLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // POST: ActivityLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Action,CreatedBy,CreatedOn")] ActivityLog activityLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityLog);
        }

        // GET: ActivityLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            if (activityLog == null)
            {
                return HttpNotFound();
            }
            return View(activityLog);
        }

        // POST: ActivityLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityLog activityLog = db.ActivityLogs.Find(id);
            db.ActivityLogs.Remove(activityLog);
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
