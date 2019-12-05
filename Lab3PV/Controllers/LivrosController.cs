using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediESTeca.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediESTeca.Controllers
{
    public class LivrosController : Controller
    {
        private List<Livro> livros;

        public LivrosController()
        {

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

        public IActionResult Catalogo()
        {
            return View(livros);
        }

        public IActionResult Destaque()
        {
            var destaques = livros.Where(l => l.EmDestaque);

            return View(destaques);
        }
    }
}