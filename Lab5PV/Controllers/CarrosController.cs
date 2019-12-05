using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ESTeCar.Models;

namespace ESTeCar.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ESTeCarContext _context;

        public CarrosController(ESTeCarContext context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index()
        {
            var eSTeCarContext = _context.Carro.Include(c => c.Marca);
            return View(await eSTeCarContext.ToListAsync());
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .Include(c => c.Marca)
                .FirstOrDefaultAsync(m => m.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Set<Marca>(), "MarcaId", "Designacao");
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarroId,MarcaId,Modelo,NumeroDePortas,TipoDeCaixa")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<Marca>(), "MarcaId", "Designacao", carro.MarcaId);
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Set<Marca>(), "MarcaId", "Designacao", carro.MarcaId);
            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarroId,MarcaId,Modelo,NumeroDePortas,TipoDeCaixa")] Carro carro)
        {
            if (id != carro.CarroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.CarroId))
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
            ViewData["MarcaId"] = new SelectList(_context.Set<Marca>(), "MarcaId", "Designacao", carro.MarcaId);
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .Include(c => c.Marca)
                .FirstOrDefaultAsync(m => m.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carro.FindAsync(id);
            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carro.Any(e => e.CarroId == id);
        }

        // GET: Carros
        public async Task<IActionResult> OrderByMarca()
        {
            var eSTeCarContext = _context.Carro.Include(c => c.Marca);
            var listaDeCarros = await eSTeCarContext.OrderBy(c => c.Marca.Designacao).ToListAsync();
            return View("Index", listaDeCarros);
        }

        // GET: Carros
        public async Task<IActionResult> OrderByModelo()
        {
            var eSTeCarContext = _context.Carro.Include(c => c.Marca);
            return View("Index", await eSTeCarContext.OrderBy(c => c.Modelo).ToListAsync());
        }

        // GET: Carros
        public async Task<IActionResult> CarrosByMarca(string marca)
        {
            var eSTeCarContext = _context.Carro.Include(c => c.Marca);
            return View("Index", await eSTeCarContext.Where(c => c.Marca.Designacao == marca).ToListAsync());
        }
    }
}
