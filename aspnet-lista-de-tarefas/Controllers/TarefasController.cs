using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_lista_de_tarefas.Data;
using aspnet_lista_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_lista_de_tarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ListaTarefasDbContext _context;
        public TarefasController(ListaTarefasDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = _context.Tarefas.Join(_context.Status, t1 => t1.StatusId, t2 => t2.StatusId,
             (t1, t2) => new { t1, t2 })
                .Join(_context.TiposTarefas, t1t2 => t1t2.t1.TipoTarefaId, t3 => t3.TipoTarefaId,
                (t1t2, t3) => new {t1t2, t3})
             .Select(
                i => new Tarefa
                {
                    TarefaId = i.t1t2.t1.TarefaId,
                    Nome = i.t1t2.t1.Nome,
                    Descricao = i.t1t2.t1.Descricao,
                    DataExecucao = i.t1t2.t1.DataExecucao,
                    StatusId = i.t1t2.t1.StatusId,
                    Status = i.t1t2.t2,
                    TipoTarefaId = i.t1t2.t1.TipoTarefaId,
                    TipoTarefa = i.t3,
                }
                //i =>  new
                //{
                //    Tarefa = i.t1,
                //    Status = i.t2
                //}
              );
            //query.Include(s => s.Status);
            query.AsNoTracking()
                .OrderByDescending(o => o.DataExecucao)
                ;

                
            return View(await query.ToListAsync());
        }

        public IActionResult Inserir()
        {
            ViewBag.Status = _context.Status;
            ViewBag.TiposTarefas = _context.TiposTarefas;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(Tarefa tarefa)
        {
            
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefa);
        }


        public IActionResult Atualizar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = _context.Tarefas.Find(id);

            ViewBag.Status = _context.Status;
            ViewBag.TiposTarefas = _context.TiposTarefas;

            return View(tarefa);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(int id,Tarefa tarefa)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefaToUpdate = await _context.Tarefas.FirstOrDefaultAsync(
                c => c.TarefaId == id
                );

            if (await TryUpdateModelAsync<Tarefa>(
                tarefaToUpdate,
                ""
                ,c => c.Nome, c => c.TipoTarefaId, c => c.Descricao, c => c.DataExecucao, c => c.StatusId
                ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }   
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                    
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Status = _context.Status;
                ViewBag.TiposTarefas = _context.TiposTarefas;

                return View(tarefa);
            }
            
        }

                
        public async Task<IActionResult> Excluir(int id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(
                c => c.TarefaId == id
                );

           
            try
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");

            }
            return RedirectToAction(nameof(Index));
           

        }




    }
}
