using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediESTeca.Models;

namespace MediESTeca.Controllers
{
    public class HomeController : Controller
    {
        private List<Livro> livros;
        private int indiceLivroDoDia = 0;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            livros = new List<Livro> {
                new Livro
                {
                    Titulo = "A programmer`s introduction to C#",
                    Autor = "Eric Gunnerson",
                    Editora = "Apress",
                    Isbn= "978-1-4302-0909-6",
                    AnoEdicao = 2001,
                    EmDestaque = false
                },
                new Livro
                {
                    Titulo = "Programação em C++ : algoritmos e estruturas de dados",
                    Autor = "Pimenta Rodrigues, Pedro Pereira, Manuela Sousa",
                    Editora = "FCA",
                    Isbn= "972-722-199-8",
                    AnoEdicao = 2000,
                    EmDestaque = false
                },
                new Livro
                {
                    Titulo = "Estruturas de dados e algoritmos em C",
                    Autor = "António Adrego da Rocha",
                    Editora = "FCA",
                    Isbn= "978-972-722-769-3",
                    AnoEdicao = 2014,
                    EmDestaque = true
                },
                new Livro
                {
                    Titulo = "C# 5.0 com Visual Studio 2012 : curso completo",
                    Autor = "Henrique Loureiro",
                    Editora = "FCA",
                    Isbn= "978-972-722-752-5",
                    AnoEdicao = 2013,
                    EmDestaque = true
                }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Nível 1
        public IActionResult Contact()
        {
            return View();
        }

        // Nível 1
        public IActionResult About()
        {
            return View();
        }

        // Nivel 2
        public IActionResult LivroDoDia()
        {
            Livro livroDoDia = livros[indiceLivroDoDia];

            ViewData["IndexLivro"] = string.Format("Livro {0} de {1}", livros.IndexOf(livroDoDia) + 1, livros.Count);

            return View(livroDoDia);
        }

        // Nível 5
        public IActionResult DescarregarIndice()
        {
            Livro livroDoDia = livros[indiceLivroDoDia];

            string filename = livroDoDia.Isbn + ".pdf";

            return File("~/Documents/" + filename, "application/pdf", filename);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
