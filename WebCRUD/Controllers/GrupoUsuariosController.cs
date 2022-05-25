using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class GrupoUsuariosController : Controller
    {
        private readonly Contexto _context;

        public GrupoUsuariosController(Contexto context)
        {
            _context = context;
        }

        // GET: GrupoUsuarios
        public async Task<IActionResult> Index()
        {
              return _context.Produto != null ? 
                          View(await _context.Produto.ToListAsync()) :
                          Problem("Entity set 'Contexto.Produto'  is null.");
        }

        // GET: GrupoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] GrupoUsuario grupoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.Produto.FindAsync(id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }
            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] GrupoUsuario grupoUsuario)
        {
            if (id != grupoUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoUsuarioExists(grupoUsuario.Id))
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
            return View(grupoUsuario);
        }

        // GET: GrupoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var grupoUsuario = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoUsuario == null)
            {
                return NotFound();
            }

            return View(grupoUsuario);
        }

        // POST: GrupoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'Contexto.Produto'  is null.");
            }
            var grupoUsuario = await _context.Produto.FindAsync(id);
            if (grupoUsuario != null)
            {
                _context.Produto.Remove(grupoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoUsuarioExists(int id)
        {
          return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
