namespace Supermarket.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Data.Context;
    using Models;

    public class MeasuresController : Controller
    {
        private SupermarketOracleContext db = new SupermarketOracleContext();

        // GET: Measures
        public ActionResult Index()
        {
            return View(db.Measures.ToList());
        }

        // GET: Measures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // GET: Measures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeasureId,MeasureName")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Measures.Add(measure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measure);
        }

        // GET: Measures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: Measures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeasureId,MeasureName")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measure);
        }

        // GET: Measures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: Measures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measure measure = db.Measures.Find(id);
            db.Measures.Remove(measure);
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
