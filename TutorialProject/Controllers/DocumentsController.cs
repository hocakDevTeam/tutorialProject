using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorialProject.DataAccess;
using TutorialProject.Models;
using TutorialProject.Models.ViewModels;

namespace TutorialProject.Controllers
{
    public class DocumentsController : Controller
    {
        private WhatEver db = new WhatEver();

        // GET: Documents
        public ActionResult Index()
        {
            return View(db.Documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        public ActionResult Download(int id)
        {
            if (id <= 0) return HttpNotFound();

            var docToDownload = db.Documents.Find(id);

            return File(docToDownload.Content,
                docToDownload.MimeType,
                docToDownload.FileName + docToDownload.FileExtension);

        }


        // GET: Documents/Create
        public ActionResult Create(int? id, int? ShoppingListId)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(new CreateDocViewModel
            {
                ShoppingListId = id.Value
            });
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDocViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (var reader = new BinaryReader(vm.File.InputStream))
                { db.Documents.Add(new Document {
                    
                    ShoppingListId = vm.ShoppingListId,
                    FileName = vm.File.FileName,
                    MimeType = vm.File.ContentType,
                    Content = reader.ReadBytes(vm.File.ContentLength),
                    CreatedBy = User.Identity.Name,
                    CreatedAt = DateTime.Now
                });
                    db.SaveChanges();
                }

                db.ActivityLogs.Add(new ActivityLog
                {
                    //ShoppingListId = vm.ShoppingListId,
                    Action = "Added Document",
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.Now,

                });
                
                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", "ShoppingList", new { id = vm.ShoppingListId });
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async System.Threading.Tasks.Task<ActionResult> Create(CreateDocViewModel vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var reader = new BinaryReader(vm.File.InputStream))
        //        {
        //            db.Documents.Add(new Document
        //            {

        //                MimeType = vm.File.ContentType,
        //                Content = reader.ReadBytes(vm.File.ContentLength),
        //                ShoppingListId = vm.ContractId,
        //                CreatedAt = DateTime.Now,
        //                CreatedBy = User.Identity.Name,
        //                FileName = vm.File.FileName,
        //                Type = vm.DocType

        //            });
        //            db.SaveChanges();
        //        }
        //        db.ActivityLogs.Add(new ActivityLog
        //        {
        //            ContractId = vm.ContractId,
        //            Action = "Added Document",
        //            CreatedBy = User.Identity.Name,
        //            CreatedOn = DateTime.Now,
        //            //Comment = User.Identity.Name + " Added a Document",
        //            //IsThisPublic = true
        //        });
        //        db.SaveChanges();


                //var contract = db.Contracts.Find(vm.ContractId);
                //var email = contract.InitiatorEmail;

                //var url = Url.Action("Details", "Contracts", new RouteValueDictionary(new { id = contract.Id }), "https", "contractdb2022.program.ho-chunk.com/");

                //using (var mail = new MailMessage())
                //using (var client = new SmtpClient())
                //{
                //    mail.To.Add(email);
                //    mail.From = new MailAddress("hcnapps@ho-chunk.com");
                //    //Add more emails as needed below
                //    //mail.To.Add() -- CopyPaste This for more emails

                //    mail.Subject = "A document has been submitted";
                //    mail.IsBodyHtml = true;
                //    mail.Priority = MailPriority.High;
                //    mail.Body = "Someone has added an additional document to your proposed contract." +
                //        "<br/>" +
                //        "<p><a href=\"" + url + "\">View Contract</a></p>";

                //    client.Credentials = new System.Net.NetworkCredential("hcnapps", "ninjavikings$");
                //    client.Host = "tobwebmail.ho-chunk.com";
                //    client.Port = 25;

                //    await client.SendMailAsync(mail);
                //}

        //    }

        //    return RedirectToAction("Details", "Contracts", new { id = vm.ShoppingListId });
        //}

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShoppingListId,FileName,MimeType,Content,FileExtension,Type,SubType,CreatedBy,CreatedAt")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
