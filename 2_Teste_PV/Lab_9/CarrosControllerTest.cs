using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstCarII.Controllers;
using EstCarII.Data;
using EstCarII.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EsteCarIITest
{
    // Para usar o mesmo objeto nos vários testes - class fixture
    public class ApplicationDbContextFixture
    {
        public ApplicationDbContext DbContext { get; private set; }

        public ApplicationDbContextFixture()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(connection)
                    .Options;
            DbContext = new ApplicationDbContext(options);

            DbContext.Database.EnsureCreated();

            // Adicionar Marcas para testes
            DbContext.Marca.AddRange(
                new Marca { Designacao = "Ferrary" },
                new Marca { Designacao = "Porsche" },
                new Marca { Designacao = "BMW" });
            DbContext.SaveChanges();

            DbContext.Carro.AddRange(
                new Carro { MarcaId = (DbContext.Marca.First(m => m.Designacao.Contains("Ferrary"))).MarcaId, Modelo = "TestaRossa", NumeroDePortas = 2, TipoDeCaixa = "Manual" },
                new Carro { MarcaId = (DbContext.Marca.First(m => m.Designacao.Contains("Porsche"))).MarcaId, Modelo = "911 Carrera", NumeroDePortas = 2, TipoDeCaixa = "Manual" });
            DbContext.SaveChanges();
        }
    }


    // Para usar a fixture definida tem de implementar a interface IClassFixture<> que não tem métodos
    public class CarrosControllerTest : IClassFixture<ApplicationDbContextFixture>
    {
        private ApplicationDbContext _context;

        public CarrosControllerTest(ApplicationDbContextFixture contextFixture)
        {
            _context = contextFixture.DbContext;
        }

        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var controller = new CarrosController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Carro>>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Index_MarcaIsIncluded_WhenLoadsFromContext()
        {
            var controller = new CarrosController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Carro>>(
                viewResult.ViewData.Model);
            Assert.NotNull(model.FirstOrDefault().Marca);
        }

        [Fact]
        public async Task CreateGet_ReturnsViewresult()
        {
            var controller = new CarrosController(_context);

            var result = controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateGet_SetsMarcaIdInViewData()
        {
            var controller = new CarrosController(_context);

            var result = controller.Create();

            var viewdata = controller.ViewData["MarcaId"];
            Assert.NotNull(viewdata);
            Assert.IsType<SelectList>(viewdata);
            Assert.True((viewdata as SelectList).Count() > 0);
        }

        [Fact]
        public async Task CreatePost_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            var controller = new CarrosController(_context);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");
            Carro porsche = new Carro { MarcaId = (_context.Marca.First(m => m.Designacao.Contains("Porsche"))).MarcaId, Modelo = "Cayenne", NumeroDePortas = 4, TipoDeCaixa = "Manual" };

            var result = await controller.Create(porsche);

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task CreatePost_ReturnsRediretionToActionResult_WhenModelStateValid()
        {
            var controller = new CarrosController(_context);
            Carro porsche = new Carro { MarcaId = (_context.Marca.First(m => m.Designacao.Contains("Porsche"))).MarcaId, Modelo = "Panamera", NumeroDePortas = 2, TipoDeCaixa = "Manual" };

            var result = await controller.Create(porsche);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task CreatePost_SetsMarcaIdInViewData_WhenModelStateInValid()
        {
            var controller = new CarrosController(_context);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");
            Carro porsche = new Carro { MarcaId = (_context.Marca.First(m => m.Designacao.Contains("Porsche"))).MarcaId, Modelo = "Cayman", NumeroDePortas = 2, TipoDeCaixa = "Manual" };

            var result = await controller.Create(porsche);

            var viewdata = controller.ViewData["MarcaId"];
            Assert.NotNull(viewdata);
            Assert.IsType<SelectList>(viewdata);
        }
    }
}
