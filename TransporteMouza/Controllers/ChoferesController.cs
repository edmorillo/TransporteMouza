using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransporteMouza.Models;

namespace TransporteMouza.Controllers
{
    public class ChoferesController : Controller
    {
        private readonly TAIContext _context;

        public ChoferesController(TAIContext context)
        {
            _context = context;
        }

        // GET: Choferes
        public async Task<IActionResult> Index()
        {
            var tAIContext = _context.Choferes.Include(c => c.ProvNavigation);
            return View(await tAIContext.ToListAsync());
        }

        // GET: Choferes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Choferes == null)
            {
                return NotFound();
            }

            var chofere = await _context.Choferes
                .Include(c => c.ProvNavigation)
                .FirstOrDefaultAsync(m => m.IdChoferes == id);
            if (chofere == null)
            {
                return NotFound();
            }

            return View(chofere);
        }

        // GET: Choferes/Create
        public IActionResult Create()
        {
            ViewData["Prov"] = new SelectList(_context.Provincia, "Provincia", "Provincia");
            return View();
        }

        // POST: Choferes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChoferes,Nombre,Apellido,Direccion,Dni,Email,Cuil,FechaNac,Telefono,Matricula,LicenciaVen,Prov")] Chofere chofere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chofere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Prov"] = new SelectList(_context.Provincia, "IdProvincia", "IdProvincia", chofere.Prov);
            return View(chofere);
        }

        // GET: Choferes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Choferes == null)
            {
                return NotFound();
            }

            var chofere = await _context.Choferes.FindAsync(id);
            if (chofere == null)
            {
                return NotFound();
            }
            ViewData["Prov"] = new SelectList(_context.Provincia, "Provincia", "Provincia", chofere.Prov);
            return View(chofere);
        }

        // POST: Choferes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChoferes,Nombre,Apellido,Direccion,Dni,Email,Cuil,FechaNac,Telefono,Matricula,LicenciaVen,Prov")] Chofere chofere)
        {
            if (id != chofere.IdChoferes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chofere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChofereExists(chofere.IdChoferes))
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
            ViewData["Prov"] = new SelectList(_context.Provincia, "Provincia", "Provincia", chofere.Prov);
            return View(chofere);
        }

        // GET: Choferes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Choferes == null)
            {
                return NotFound();
            }

            var chofere = await _context.Choferes
                .Include(c => c.ProvNavigation)
                .FirstOrDefaultAsync(m => m.IdChoferes == id);
            if (chofere == null)
            {
                return NotFound();
            }

            return View(chofere);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Choferes == null)
            {
                return Problem("Entity set 'TAIContext.Choferes'  is null.");
            }
            var chofere = await _context.Choferes.FindAsync(id);
            if (chofere != null)
            {
                _context.Choferes.Remove(chofere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChofereExists(int id)
        {
          return (_context.Choferes?.Any(e => e.IdChoferes == id)).GetValueOrDefault();
        }
    }
}
