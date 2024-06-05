using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acho.Models;

namespace Acho.Controllers
{
    public class ObservacoesController : Controller
    {
        private readonly Contexto _context;

        public ObservacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Observacoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Observacoes.Include(o => o.Animais).Include(o => o.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Observacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Observacoes == null)
            {
                return NotFound();
            }

            var observacoes = await _context.Observacoes
                .Include(o => o.Animais)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (observacoes == null)
            {
                return NotFound();
            }

            return View(observacoes);
        }

        // GET: Observacoes/Create
        public IActionResult Create()
        {
            ViewData["AnimaisId"] = new SelectList(_context.Animal, "AnimaisId", "AnimalNome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioNome");
            return View();
        }

        // POST: Observacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObservacaoDescricao,ObservacaoLocal,ObservacaoData,AnimaisId,UsuarioId")] Observacoes observacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(observacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimaisId"] = new SelectList(_context.Animal, "AnimaisId", "AnimalNome", observacoes.AnimaisId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioNome", observacoes.UsuarioId);
            return View(observacoes);
        }

        // GET: Observacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Observacoes == null)
            {
                return NotFound();
            }

            var observacoes = await _context.Observacoes.FindAsync(id);
            if (observacoes == null)
            {
                return NotFound();
            }
            ViewData["AnimaisId"] = new SelectList(_context.Animal, "AnimaisId", "AnimalNome", observacoes.AnimaisId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioNome", observacoes.UsuarioId);
            return View(observacoes);
        }

        // POST: Observacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObservacaoDescricao,ObservacaoLocal,ObservacaoData,AnimaisId,UsuarioId")] Observacoes observacoes)
        {
            if (id != observacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(observacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObservacoesExists(observacoes.Id))
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
            ViewData["AnimaisId"] = new SelectList(_context.Animal, "AnimaisId", "AnimalNome", observacoes.AnimaisId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioNome", observacoes.UsuarioId);
            return View(observacoes);
        }

        // GET: Observacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Observacoes == null)
            {
                return NotFound();
            }

            var observacoes = await _context.Observacoes
                .Include(o => o.Animais)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (observacoes == null)
            {
                return NotFound();
            }

            return View(observacoes);
        }

        // POST: Observacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Observacoes == null)
            {
                return Problem("Entity set 'Contexto.Observacoes'  is null.");
            }
            var observacoes = await _context.Observacoes.FindAsync(id);
            if (observacoes != null)
            {
                _context.Observacoes.Remove(observacoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObservacoesExists(int id)
        {
          return (_context.Observacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
