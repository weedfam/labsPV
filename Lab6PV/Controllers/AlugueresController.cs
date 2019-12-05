using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstCarII.Data;
using EstCarII.Models;
using Microsoft.AspNetCore.Authorization;

namespace EstCarII.Controllers
{
    [Authorize]
    public class AlugueresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlugueresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alugueres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aluguer.Include(a => a.Carro).Include(a => a.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alugueres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer
                .Include(a => a.Carro)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.AluguerId == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // GET: Alugueres/Create
        public IActionResult Create()
        {
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "Modelo");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome");
            return View();
        }

        // POST: Alugueres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AluguerId,CarroId,UserId,LocalDeEntrega,LocalDeRecolha,DataInicio,DataFim")] Aluguer aluguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "Modelo", aluguer.CarroId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", aluguer.UserId);
            return View(aluguer);
        }

        // GET: Alugueres/Edit/5
        [Authorize(Roles = "admins")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer.FindAsync(id);
            if (aluguer == null)
            {
                return NotFound();
            }
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "Modelo", aluguer.CarroId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", aluguer.UserId);
            return View(aluguer);
        }

        // POST: Alugueres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admins")]
        public async Task<IActionResult> Edit(int id, [Bind("AluguerId,CarroId,UserId,LocalDeEntrega,LocalDeRecolha,DataInicio,DataFim")] Aluguer aluguer)
        {
            if (id != aluguer.AluguerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguerExists(aluguer.AluguerId))
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
            ViewData["CarroId"] = new SelectList(_context.Carro, "CarroId", "Modelo", aluguer.CarroId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Nome", aluguer.UserId);
            return View(aluguer);
        }

        // GET: Alugueres/Delete/5
        [Authorize(Roles = "admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Aluguer
                .Include(a => a.Carro)
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.AluguerId == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // POST: Alugueres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguer = await _context.Aluguer.FindAsync(id);
            _context.Aluguer.Remove(aluguer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguerExists(int id)
        {
            return _context.Aluguer.Any(e => e.AluguerId == id);
        }
    }
}
