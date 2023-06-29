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
    public class NeumaticoesController : Controller
    {
        private readonly TAIContext _context;

        public NeumaticoesController(TAIContext context)
        {
            _context = context;
        }

        // GET: Neumaticoes
        public async Task<IActionResult> Index()
        {
            var tAIContext = _context.Neumaticos.Include(n => n.IdCompraNavigation).Include(n => n.IdTipoUnidadNavigation);
            return View(await tAIContext.ToListAsync());
        }

        // GET: Neumaticoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Neumaticos == null)
            {
                return NotFound();
            }

            var neumatico = await _context.Neumaticos
                .Include(n => n.IdCompraNavigation)
                .Include(n => n.IdTipoUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdNeumatico == id);
            if (neumatico == null)
            {
                return NotFound();
            }

            return View(neumatico);
        }

        // GET: Neumaticoes/Create
        public IActionResult Create()
        {
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["IdTipoUnidad"] = new SelectList(_context.TipoUnidades, "IdTipoUnidad", "IdTipoUnidad");
            return View();
        }

        // POST: Neumaticoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNeumatico,Marca,Rodado,Modelo,IdTipoUnidad,Detalle,IdCompra")] Neumatico neumatico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neumatico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", neumatico.IdCompra);
            ViewData["IdTipoUnidad"] = new SelectList(_context.TipoUnidades, "IdTipoUnidad", "IdTipoUnidad", neumatico.IdTipoUnidad);
            return View(neumatico);
        }

        // GET: Neumaticoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Neumaticos == null)
            {
                return NotFound();
            }

            var neumatico = await _context.Neumaticos.FindAsync(id);
            if (neumatico == null)
            {
                return NotFound();
            }
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", neumatico.IdCompra);
            ViewData["IdTipoUnidad"] = new SelectList(_context.TipoUnidades, "IdTipoUnidad", "IdTipoUnidad", neumatico.IdTipoUnidad);
            return View(neumatico);
        }

        // POST: Neumaticoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNeumatico,Marca,Rodado,Modelo,IdTipoUnidad,Detalle,IdCompra")] Neumatico neumatico)
        {
            if (id != neumatico.IdNeumatico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neumatico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeumaticoExists(neumatico.IdNeumatico))
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
            ViewData["IdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", neumatico.IdCompra);
            ViewData["IdTipoUnidad"] = new SelectList(_context.TipoUnidades, "IdTipoUnidad", "IdTipoUnidad", neumatico.IdTipoUnidad);
            return View(neumatico);
        }

        // GET: Neumaticoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Neumaticos == null)
            {
                return NotFound();
            }

            var neumatico = await _context.Neumaticos
                .Include(n => n.IdCompraNavigation)
                .Include(n => n.IdTipoUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdNeumatico == id);
            if (neumatico == null)
            {
                return NotFound();
            }

            return View(neumatico);
        }

        // POST: Neumaticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Neumaticos == null)
            {
                return Problem("Entity set 'TAIContext.Neumaticos'  is null.");
            }
            var neumatico = await _context.Neumaticos.FindAsync(id);
            if (neumatico != null)
            {
                _context.Neumaticos.Remove(neumatico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeumaticoExists(int id)
        {
          return (_context.Neumaticos?.Any(e => e.IdNeumatico == id)).GetValueOrDefault();
        }
    }
}
