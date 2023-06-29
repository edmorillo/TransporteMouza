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
    public class UnidadsController : Controller
    {
        private readonly TAIContext _context;

        public UnidadsController(TAIContext context)
        {
            _context = context;
        }

        // GET: Unidads
        public async Task<IActionResult> Index()
        {
              return _context.Unidads != null ? 
                          View(await _context.Unidads.ToListAsync()) :
                          Problem("Entity set 'TAIContext.Unidads'  is null.");
        }

        // GET: Unidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUnidad,Matricula,IdMarca,Modelo,AñoUnidad,CapacidadCarga,IdChoferes,FecCompra,FecMantenimiento,Kilometros,EstadoDocumentacion,IdTipoUnidad")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad);
        }

        // GET: Unidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            return View(unidad);
        }

        // POST: Unidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUnidad,Matricula,IdMarca,Modelo,AñoUnidad,CapacidadCarga,IdChoferes,FecCompra,FecMantenimiento,Kilometros,EstadoDocumentacion,IdTipoUnidad")] Unidad unidad)
        {
            if (id != unidad.IdUnidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.IdUnidad))
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
            return View(unidad);
        }

        // GET: Unidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidads == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidads
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidads == null)
            {
                return Problem("Entity set 'TAIContext.Unidads'  is null.");
            }
            var unidad = await _context.Unidads.FindAsync(id);
            if (unidad != null)
            {
                _context.Unidads.Remove(unidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
          return (_context.Unidads?.Any(e => e.IdUnidad == id)).GetValueOrDefault();
        }
    }
}
