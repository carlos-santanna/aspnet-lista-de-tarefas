using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnet_lista_de_tarefas.Data;
using aspnet_lista_de_tarefas.Models;

namespace aspnet_lista_de_tarefas.Controllers
{
    public class TipoTarefasController : Controller
    {
        private readonly ListaTarefasDbContext _context;

        public TipoTarefasController(ListaTarefasDbContext context)
        {
            _context = context;
        }

        // GET: TipoTarefas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposTarefas.ToListAsync());
        }

        // GET: TipoTarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarefa = await _context.TiposTarefas
                .FirstOrDefaultAsync(m => m.TipoTarefaId == id);
            if (tipoTarefa == null)
            {
                return NotFound();
            }

            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoTarefaId,Tipo")] TipoTarefa tipoTarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarefa = await _context.TiposTarefas.FindAsync(id);
            if (tipoTarefa == null)
            {
                return NotFound();
            }
            return View(tipoTarefa);
        }

        // POST: TipoTarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoTarefaId,Tipo")] TipoTarefa tipoTarefa)
        {
            if (id != tipoTarefa.TipoTarefaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTarefaExists(tipoTarefa.TipoTarefaId))
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
            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarefa = await _context.TiposTarefas
                .FirstOrDefaultAsync(m => m.TipoTarefaId == id);
            if (tipoTarefa == null)
            {
                return NotFound();
            }

            return View(tipoTarefa);
        }

        // POST: TipoTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTarefa = await _context.TiposTarefas.FindAsync(id);
            _context.TiposTarefas.Remove(tipoTarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTarefaExists(int id)
        {
            return _context.TiposTarefas.Any(e => e.TipoTarefaId == id);
        }
    }
}
