using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bourse.Models;
using System.Linq.Dynamic;
namespace Bourse.Controllers
{
    public class SymbolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Symbols
        public ActionResult Index(int id)
        {
            ViewBag.symbolId = id;
            return View();
        }

        [HttpPost]
        public ActionResult LoadData(int symbolId)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var symbols = (from a in db.Symbols
                               where a.SubCategoriesId == symbolId
                               select new
                               {
                                   a.Name,
                                   a.Date,
                                   a.Last,
                                   a.Low,
                                   a.First,
                               });

                //Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    symbols = symbols.OrderBy(sortColumn + " " + sortColumnDir);
                }

                totalRecords = symbols.Count();
                var data = symbols.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data }, JsonRequestBehavior.AllowGet);

            }

        }
        // GET: Symbols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            return View(symbol);
        }

        // GET: Symbols/Create
        public ActionResult Create()
        {
            ViewBag.SubCategoriesId = new SelectList(db.SubCategories, "Id", "Name");
            return View();
        }

        // POST: Symbols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date,First,High,Low,Close,Value,Volume,OpenInt,Per,Open,Last,SubCategoriesId")] Symbol symbol)
        {
            if (ModelState.IsValid)
            {
                db.Symbols.Add(symbol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoriesId = new SelectList(db.SubCategories, "Id", "Name", symbol.SubCategoriesId);
            return View(symbol);
        }

        // GET: Symbols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoriesId = new SelectList(db.SubCategories, "Id", "Name", symbol.SubCategoriesId);
            return View(symbol);
        }

        // POST: Symbols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Date,First,High,Low,Close,Value,Volume,OpenInt,Per,Open,Last,SubCategoriesId")] Symbol symbol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symbol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoriesId = new SelectList(db.SubCategories, "Id", "Name", symbol.SubCategoriesId);
            return View(symbol);
        }

        // GET: Symbols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return HttpNotFound();
            }
            return View(symbol);
        }

        // POST: Symbols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Symbol symbol = db.Symbols.Find(id);
            db.Symbols.Remove(symbol);
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
