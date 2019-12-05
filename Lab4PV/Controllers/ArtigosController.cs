using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTaPapelaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESTaPapelaria.Controllers
{
    public class ArtigosController : Controller
    {
        private List<Artigo> artigos = Program.BDArtigos;
        public IActionResult Listar()
        {
            return View(artigos);
        }

        public IActionResult Promocoes()
        {
            return View(artigos.Where(a => a.EmPromocao));
        }

        [HttpPost]
        public IActionResult Listar(string filtro)
        {
            var artigosFiltrados = from a in artigos select a;

            if (!String.IsNullOrEmpty(filtro))
            {
                artigosFiltrados = artigosFiltrados.Where(a => a.Nome.Contains(filtro));
            }

            return View(artigosFiltrados.ToList());
        }

        public IActionResult Editar(int? id)
        {
            Artigo artigo = artigos.Find(a => a.Id == id);

            return View(artigo);
        }

        [HttpPost]
        public IActionResult Editar(int id, Artigo artigo)
        {
            Artigo ArtigoNaBD = artigos.Find(a => a.Id == id);

            ArtigoNaBD.Desconto = artigo.Desconto;
            ArtigoNaBD.Descricao = artigo.Descricao;
            ArtigoNaBD.EmPromocao = artigo.EmPromocao;
            ArtigoNaBD.Nome = artigo.Nome;
            ArtigoNaBD.Preco = artigo.Preco;

            return View(ArtigoNaBD);
        }

    }
}