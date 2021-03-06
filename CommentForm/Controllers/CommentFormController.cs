﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommentForm.Models;

namespace CommentForm.Controllers
{
    public class CommentFormController : Controller
    {
        private CommentFormContext db = new CommentFormContext();

        // GET: CommentForm
        public ActionResult Index()
        {
            return View(db.CommentFormModels.ToList());
        }

        // GET: CommentForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }


            //Daniel: We can populate our new view model entity with a linq query. We have a lot of flexibility
            var viewModel = new CommentFormViewModel
            {
                //We can reuse the comment form from a couple of lines above
                CommentForm = commentFormModel,
                //We don't want to pull back all the procedures, just the one with the same priority as our comment
                Procedure = (from p in db.ProcedureModels
                             where p.Priority == commentFormModel.Priority
                             select p).First()
            };

            //Daniel: We can no longer pass back a comment form. We need to pass back our new view model
            return View(viewModel);

            // This was was we retunred before
            //return View(commentFormModel);
        }

        // GET: CommentForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Comment,Priority")] CommentFormModel commentFormModel)
        {
            if (ModelState.IsValid)
            {
                db.CommentFormModels.Add(commentFormModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentFormModel);
        }

        // GET: CommentForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }
            return View(commentFormModel);
        }

        // POST: CommentForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Comment,Priority")] CommentFormModel commentFormModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentFormModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentFormModel);
        }

        // GET: CommentForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }
            return View(commentFormModel);
        }

        // POST: CommentForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            db.CommentFormModels.Remove(commentFormModel);
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
