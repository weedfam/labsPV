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
    public class MarcasController : Controller
    {
        private readonly ESTeCarContext _context;

        public MarcasController(ESTeCarContext context)
        {
            _context = context;
        }

        // GET: Marcas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marca.ToListAsync());
        }
        
    }
}
