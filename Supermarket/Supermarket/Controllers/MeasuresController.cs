namespace Supermarket.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Supermarket.Models;

    public class MeasuresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Measures
        public async Task<ActionResult> Index()
        {
            return View(await db.Measures.ToListAsync());
        }

        // GET: Measures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "MeasureId,MeasureName")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Measures.Add(measure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(measure);
        }

        // GET: Measures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "MeasureId,MeasureName")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(measure);
        }

        // GET: Measures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measure measure = await db.Measures.FindAsync(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: Measures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Measure measure = await db.Measures.FindAsync(id);
            db.Measures.Remove(measure);
            await db.SaveChangesAsync();
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
