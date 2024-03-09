using BeerCanSite.Data;
using BeerCanSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeerCanSite.Controllers
{
    public class BeerCansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeerCansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BeerCans
        public async Task<IActionResult> Index(string SortOrder)
        {
            return View(await _context.BeerCan.ToListAsync());
        }

        // GET: BeerCans/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View(await _context.BeerCan.ToListAsync());
        }

        // PoST: BeerCans/ShowSearchResults //For Name or brand name
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.BeerCan.Where(b => b.BeerCanName.Contains(SearchPhrase) || b.BeerBrand.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: BeerCans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerCan = await _context.BeerCan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beerCan == null)
            {
                return NotFound();
            }

            return View(beerCan);
        }

        // GET: BeerCans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeerCans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BeerCanName,BeerBrand,BeerCanDescription,ManufactureDate,TopType,OpenedStatus,ContainerSize,Grade,Circulated,Instructional,Images")] BeerCan beerCan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beerCan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beerCan);
        }

        // GET: BeerCans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerCan = await _context.BeerCan.FindAsync(id);
            if (beerCan == null)
            {
                return NotFound();
            }
            return View(beerCan);
        }

        // POST: BeerCans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeerCanName,BeerBrand,BeerCanDescription,ManufactureDate,TopType,OpenedStatus,ContainerSize,Grade,Circulated,Instructional,Images")] BeerCan beerCan)
        {
            if (id != beerCan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beerCan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerCanExists(beerCan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beerCan);
        }

        // GET: BeerCans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerCan = await _context.BeerCan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beerCan == null)
            {
                return NotFound();
            }

            return View(beerCan);
        }

        // POST: BeerCans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beerCan = await _context.BeerCan.FindAsync(id);
            if (beerCan != null)
            {
                _context.BeerCan.Remove(beerCan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerCanExists(int id)
        {
            return _context.BeerCan.Any(e => e.Id == id);
        }
    }
}
