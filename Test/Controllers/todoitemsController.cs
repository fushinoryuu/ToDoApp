using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class todoitemsController : Controller
    {
        private webappEntities db = new webappEntities();

        // GET: todoitems
        public ActionResult Index()
        {
            return View(db.todoitems.ToList());
        }

        // GET: todoitems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todoitem todoitem = db.todoitems.Find(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            return View(todoitem);
        }

        // GET: todoitems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: todoitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,IsCompleted,DueDate,Notes")] todoitem todoitem)
        {
            if (ModelState.IsValid)
            {
                db.todoitems.Add(todoitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoitem);
        }

        // GET: todoitems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todoitem todoitem = db.todoitems.Find(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            return View(todoitem);
        }

        // POST: todoitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,IsCompleted,DueDate,Notes")] todoitem todoitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoitem);
        }

        // GET: todoitems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            todoitem todoitem = db.todoitems.Find(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            return View(todoitem);
        }

        // POST: todoitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            todoitem todoitem = db.todoitems.Find(id);
            db.todoitems.Remove(todoitem);
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
