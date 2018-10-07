using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMvc.Data;

namespace WebAppMvc.Controllers
{
    public class SomeThingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SomeThingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SomeThing
        public async Task<IActionResult> Index()
        {
            return View(await _context.SomeThings.ToListAsync());
        }

        // GET: SomeThing/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someThing = await _context.SomeThings
                .FirstOrDefaultAsync(m => m.SomeThingId == id);
            if (someThing == null)
            {
                return NotFound();
            }

            return View(someThing);
        }

        // GET: SomeThing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SomeThing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SomeThingId,Name")] SomeThing someThing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(someThing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(someThing);
        }

        // GET: SomeThing/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someThing = await _context.SomeThings.FindAsync(id);
            if (someThing == null)
            {
                return NotFound();
            }
            return View(someThing);
        }

        // POST: SomeThing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SomeThingId,Name")] SomeThing someThing)
        {
            if (id != someThing.SomeThingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(someThing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SomeThingExists(someThing.SomeThingId))
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
            return View(someThing);
        }

        // GET: SomeThing/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var someThing = await _context.SomeThings
                .FirstOrDefaultAsync(m => m.SomeThingId == id);
            if (someThing == null)
            {
                return NotFound();
            }

            return View(someThing);
        }

        // POST: SomeThing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var someThing = await _context.SomeThings.FindAsync(id);
            _context.SomeThings.Remove(someThing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SomeThingExists(string id)
        {
            return _context.SomeThings.Any(e => e.SomeThingId == id);
        }
    }
}
