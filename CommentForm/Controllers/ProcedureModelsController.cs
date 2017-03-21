using System;
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
    public class ProcedureModelsController : Controller
    {
        private CommentFormContext db = new CommentFormContext();

        // GET: ProcedureModels
        public ActionResult Index()
        {
            return View(db.ProcedureModels.ToList());
        }

        // GET: ProcedureModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // GET: ProcedureModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedureModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Priority,Title,Details")] ProcedureModel procedureModel)
        {
            if (ModelState.IsValid)
            {
                db.ProcedureModels.Add(procedureModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedureModel);
        }

        // GET: ProcedureModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // POST: ProcedureModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Priority,Title,Details")] ProcedureModel procedureModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedureModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedureModel);
        }

        // GET: ProcedureModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            if (procedureModel == null)
            {
                return HttpNotFound();
            }
            return View(procedureModel);
        }

        // POST: ProcedureModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcedureModel procedureModel = db.ProcedureModels.Find(id);
            db.ProcedureModels.Remove(procedureModel);
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
