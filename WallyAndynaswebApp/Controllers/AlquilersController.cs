using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WallyAndynaswebApp.Context;
using WallyAndynaswebApp.Models;

namespace WallyAndynaswebApp.Controllers
{
    public class AlquilersController : Controller
    {
        private readonly MiContext _context;

        public AlquilersController(MiContext context)
        {
            _context = context;
        }

        // GET: Alquilers
        public async Task<IActionResult> Index()
        {
            var miContext = _context.Alquilers.Include(a => a.Cancha).Include(a => a.Usuario);
            return View(await miContext.ToListAsync());
        }

        // GET: Alquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alquilers == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers
                .Include(a => a.Cancha)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquilers/Create
        public IActionResult Create()
        {
            ViewData["CanchaId"] = new SelectList(_context.Canchas, "Id", "Descripcion");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Contraseña");
            return View();
        }

        // POST: Alquilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumCancha,Cliente,CedIden,Celular,Fecha,Horas,Desde,Hasta,Costo,Estado,UsuarioId,CanchaId")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanchaId"] = new SelectList(_context.Canchas, "Id", "Descripcion", alquiler.CanchaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Contraseña", alquiler.UsuarioId);
            return View(alquiler);
        }

        // GET: Alquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alquilers == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["CanchaId"] = new SelectList(_context.Canchas, "Id", "Descripcion", alquiler.CanchaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Contraseña", alquiler.UsuarioId);
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumCancha,Cliente,CedIden,Celular,Fecha,Horas,Desde,Hasta,Costo,Estado,UsuarioId,CanchaId")] Alquiler alquiler)
        {
            if (id != alquiler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.Id))
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
            ViewData["CanchaId"] = new SelectList(_context.Canchas, "Id", "Descripcion", alquiler.CanchaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Contraseña", alquiler.UsuarioId);
            return View(alquiler);
        }

        // GET: Alquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alquilers == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquilers
                .Include(a => a.Cancha)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alquilers == null)
            {
                return Problem("Entity set 'MiContext.Alquilers'  is null.");
            }
            var alquiler = await _context.Alquilers.FindAsync(id);
            if (alquiler != null)
            {
                _context.Alquilers.Remove(alquiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
          return (_context.Alquilers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
