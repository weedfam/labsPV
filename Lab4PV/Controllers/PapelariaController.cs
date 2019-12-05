using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ESTaPapelaria.Controllers
{
    public class PapelariaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}