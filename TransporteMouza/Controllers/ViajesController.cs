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
    public class ViajesController : Controller
    {
        private readonly TAIContext _context;

        public ViajesController(TAIContext context)
        {
            _context = context;
        }

        // GET: Viajes
        public async Task<IActionResult> Index()
        {
            var tAIContext = _context.Viajes.Include(v => v.IdChoferesNavigation).Include(v => v.IdClienteNavigation).Include(v => v.IdUnidadNavigation);
            return View(await tAIContext.ToListAsync());
        }

        // GET: Viajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdChoferesNavigation)
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdViajes == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // GET: Viajes/Create
        public IActionResult Create()
        {
            ViewData["IdChoferes"] = new SelectList(_context.Choferes, "IdChoferes", "IdChoferes");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdUnidad"] = new SelectList(_context.Unidads, "IdUnidad", "IdUnidad");
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdViajes,Origen,Destino,IdChoferes,IdUnidad,IdCliente,Tarifa,Detalle,Remito,NumContenedor")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChoferes"] = new SelectList(_context.Choferes, "IdChoferes", "IdChoferes", viaje.IdChoferes);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdUnidad"] = new SelectList(_context.Unidads, "IdUnidad", "IdUnidad", viaje.IdUnidad);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["IdChoferes"] = new SelectList(_context.Choferes, "IdChoferes", "IdChoferes", viaje.IdChoferes);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdUnidad"] = new SelectList(_context.Unidads, "IdUnidad", "IdUnidad", viaje.IdUnidad);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdViajes,Origen,Destino,IdChoferes,IdUnidad,IdCliente,Tarifa,Detalle,Remito,NumContenedor")] Viaje viaje)
        {
            if (id != viaje.IdViajes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.IdViajes))
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
            ViewData["IdChoferes"] = new SelectList(_context.Choferes, "IdChoferes", "IdChoferes", viaje.IdChoferes);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", viaje.IdCliente);
            ViewData["IdUnidad"] = new SelectList(_context.Unidads, "IdUnidad", "IdUnidad", viaje.IdUnidad);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viajes == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdChoferesNavigation)
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdUnidadNavigation)
                .FirstOrDefaultAsync(m => m.IdViajes == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viajes == null)
            {
                return Problem("Entity set 'TAIContext.Viajes'  is null.");
            }
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje != null)
            {
                _context.Viajes.Remove(viaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajeExists(int id)
        {
          return (_context.Viajes?.Any(e => e.IdViajes == id)).GetValueOrDefault();
        }
    }
}
