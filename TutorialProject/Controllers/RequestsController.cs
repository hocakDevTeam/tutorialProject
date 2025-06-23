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
using TutorialProject.Models.ViewModels;

namespace TutorialProject.Controllers
{
    public class RequestsController : Controller
    {
        private WhatEver db = new WhatEver();

        // GET: Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View(new CreateRequestViewModel { });
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRequestViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var request = new Request
                {
                    Id = vm.Id,
                    Name = vm.Name,
                    Quantity = vm.Quantity,
                    Location = vm.Location,
                    Date = vm.Date,
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.Now,
                    Archived = false
                };

                db.Requests.Add(request);
                db.SaveChanges();



                db.ActivityLogs.Add(new ActivityLog {
                    RequestId = request.Id,
                    Action = "Created",
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.Now
                });
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
    }

    // GET: Requests/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Request request = db.Requests.Find(id);
        if (request == null)
        {
            return HttpNotFound();
        }
        return View(request);
    }

    // POST: Requests/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,Quantity,Location,Date,CreatedBy,CreatedOn,Archived")] Request request)
    {
        if (ModelState.IsValid)
        {
            db.Entry(request).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(request);
    }

    // GET: Requests/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Request request = db.Requests.Find(id);
        if (request == null)
        {
            return HttpNotFound();
        }
        return View(request);
    }

    // POST: Requests/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Request request = db.Requests.Find(id);
        db.Requests.Remove(request);
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
