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
    public class TipoUnidadesController : Controller
    {
        private readonly TAIContext _context;

        public TipoUnidadesController(TAIContext context)
        {
            _context = context;
        }

        // GET: TipoUnidades
        public async Task<IActionResult> Index()
        {
              return _context.TipoUnidades != null ? 
                          View(await _context.TipoUnidades.ToListAsync()) :
                          Problem("Entity set 'TAIContext.TipoUnidades'  is null.");
        }

        // GET: TipoUnidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoUnidades == null)
            {
                return NotFound();
            }

            var tipoUnidade = await _context.TipoUnidades
                .FirstOrDefaultAsync(m => m.IdTipoUnidad == id);
            if (tipoUnidade == null)
            {
                return NotFound();
            }

            return View(tipoUnidade);
        }

        // GET: TipoUnidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUnidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoUnidad,Detalle,Chasis")] TipoUnidade tipoUnidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUnidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUnidade);
        }

        // GET: TipoUnidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoUnidades == null)
            {
                return NotFound();
            }

            var tipoUnidade = await _context.TipoUnidades.FindAsync(id);
            if (tipoUnidade == null)
            {
                return NotFound();
            }
            return View(tipoUnidade);
        }

        // POST: TipoUnidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoUnidad,Detalle,Chasis")] TipoUnidade tipoUnidade)
        {
            if (id != tipoUnidade.IdTipoUnidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUnidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUnidadeExists(tipoUnidade.IdTipoUnidad))
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
            return View(tipoUnidade);
        }

        // GET: TipoUnidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoUnidades == null)
            {
                return NotFound();
            }

            var tipoUnidade = await _context.TipoUnidades
                .FirstOrDefaultAsync(m => m.IdTipoUnidad == id);
            if (tipoUnidade == null)
            {
                return NotFound();
            }

            return View(tipoUnidade);
        }

        // POST: TipoUnidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoUnidades == null)
            {
                return Problem("Entity set 'TAIContext.TipoUnidades'  is null.");
            }
            var tipoUnidade = await _context.TipoUnidades.FindAsync(id);
            if (tipoUnidade != null)
            {
                _context.TipoUnidades.Remove(tipoUnidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUnidadeExists(int id)
        {
          return (_context.TipoUnidades?.Any(e => e.IdTipoUnidad == id)).GetValueOrDefault();
        }
    }
}
