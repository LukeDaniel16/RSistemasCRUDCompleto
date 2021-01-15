using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSistemasCRUDCompleto.Models;

namespace RSistemasCRUDCompleto.Controllers
{
    public class GrupoDeProdutosController : Controller
    {
        private readonly GrupoProdutosContext _context;

        public GrupoDeProdutosController(GrupoProdutosContext context)
        {
            _context = context;
        }

        // GET: GrupoDeProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.grupoDeProdutos.ToListAsync());
        }

        // GET: GrupoDeProdutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoDeProdutos = await _context.grupoDeProdutos
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (grupoDeProdutos == null)
            {
                return NotFound();
            }

            return View(grupoDeProdutos);
        }

        // GET: GrupoDeProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoDeProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao,Status")] GrupoDeProdutos grupoDeProdutos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoDeProdutos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoDeProdutos);
        }

        // GET: GrupoDeProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoDeProdutos = await _context.grupoDeProdutos.FindAsync(id);
            if (grupoDeProdutos == null)
            {
                return NotFound();
            }
            return View(grupoDeProdutos);
        }

        // POST: GrupoDeProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Descricao,Status")] GrupoDeProdutos grupoDeProdutos)
        {
            if (id != grupoDeProdutos.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoDeProdutos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoDeProdutosExists(grupoDeProdutos.Codigo))
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
            return View(grupoDeProdutos);
        }

        // GET: GrupoDeProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoDeProdutos = await _context.grupoDeProdutos
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (grupoDeProdutos == null)
            {
                return NotFound();
            }

            return View(grupoDeProdutos);
        }

        // POST: GrupoDeProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoDeProdutos = await _context.grupoDeProdutos.FindAsync(id);
            _context.grupoDeProdutos.Remove(grupoDeProdutos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoDeProdutosExists(int id)
        {
            return _context.grupoDeProdutos.Any(e => e.Codigo == id);
        }
    }
}
