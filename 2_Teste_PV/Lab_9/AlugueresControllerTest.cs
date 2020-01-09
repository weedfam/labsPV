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
    public class ApplicationDbContextFixture2
    {
        public ApplicationDbContext DbContext { get; private set; }

        public ApplicationDbContextFixture2()
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

            // neste caso não é necessário usar o UserManager ou o RoleManager
            DbContext.Users.AddRange(
                new Cliente { Id = Guid.NewGuid().ToString(), Nome = "admin", UserName = "admin@estecar.pt", Email = "admin@estecar.pt" },
                new Cliente { Id = Guid.NewGuid().ToString(), Nome = "joao", UserName = "joao@estecar.pt", Email = "admin@estecar.pt" },
            new Cliente { Id = Guid.NewGuid().ToString(), Nome = "ana", UserName = "ana@estecar.pt", Email = "ana@estecar.pt" });
            DbContext.SaveChanges();

            Carro carro1 = DbContext.Carro.FirstOrDefault();
            Carro carro2 = DbContext.Carro.FirstOrDefault(c => c.CarroId == 2);
            Cliente cliente1 = DbContext.Users.FirstOrDefault(u => u.Nome == "joao");
            Cliente cliente2 = DbContext.Users.FirstOrDefault(u => u.Nome == "ana");

            var aluguer1 = new Aluguer
            {
                Carro = carro1,
                CarroId = carro1.CarroId,
                Cliente = cliente1,
                UserId = cliente1.Id,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(7),
            };
            var aluguer2 = new Aluguer
            {
                Carro = carro2,
                CarroId = carro2.CarroId,
                Cliente = cliente2,
                UserId = cliente2.Id,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(2),
            };
            var aluguer3 = new Aluguer
            {
                Carro = carro2,
                CarroId = carro2.CarroId,
                Cliente = cliente2,
                UserId = cliente2.Id,
                DataInicio = DateTime.Now.AddDays(7),
                DataFim = DateTime.Now.AddDays(9),
            };
            var aluguer4 = new Aluguer
            {
                Carro = carro2,
                CarroId = carro2.CarroId,
                Cliente = cliente1,
                UserId = cliente1.Id,
                DataInicio = DateTime.Now.AddDays(15),
                DataFim = DateTime.Now.AddDays(20),
            };
            var aluguer5 = new Aluguer
            {
                Carro = carro2,
                CarroId = carro2.CarroId,
                Cliente = cliente1,
                UserId = cliente1.Id,
                DataInicio = DateTime.Now.AddDays(21),
                DataFim = DateTime.Now.AddDays(24),
            };

            DbContext.Aluguer.AddRange(aluguer1, aluguer2, aluguer3, aluguer4, aluguer5);
            DbContext.SaveChanges();
        }
    }

    // Para usar a fixture definida tem de implementar a interface IClassFixture<> que não tem métodos
    public class AlugueresControllerTest : IClassFixture<ApplicationDbContextFixture2>
    {
        private ApplicationDbContext _context;

        public AlugueresControllerTest(ApplicationDbContextFixture2 contextFixture)
        {
            _context = contextFixture.DbContext;
        }

        [Fact]
        public async Task Index_CanLoadFromContext()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Aluguer>>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Index_CarroIsIncluded_WhenLoadsFromContext()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Aluguer>>(
                viewResult.ViewData.Model);
            Assert.NotNull(model.FirstOrDefault().Carro);
        }

        [Fact]
        public async Task Index_ClienteIsIncluded_WhenLoadsFromContext()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Aluguer>>(
                viewResult.ViewData.Model);
            Assert.NotNull(model.FirstOrDefault().Cliente);
        }

        [Fact]
        public void AluguerExists_ReturnsTrue_WhenItExists()
        {
            var controller = new AlugueresController(_context);

            var result = controller.AluguerExists(1);

            Assert.True(result);
        }

        [Fact]
        public void AluguerExists_ReturnsFalse_WhenItDoesntExist()
        {
            var controller = new AlugueresController(_context);

            var result = controller.AluguerExists(0);

            Assert.False(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenIdIsNull()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Delete(null);

            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenAluguerDoesntExist()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Delete(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsViewResult_WhenAluguerExist()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Delete(3);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Aluguer>(viewResult.ViewData.Model);
            Assert.NotNull(model);
            Assert.Equal(3, model.AluguerId);

            // Estes testes deveriam estar separados em diferentes métodos de teste!
            Assert.NotNull(model.Carro);
            Assert.NotNull(model.Cliente);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.DeleteConfirmed(4);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsNotFoundResult_WhenIdIsNull()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Edit(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsNotFoundResult_WhenAluguerDoesnsExist()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Edit(0);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditGet_ReturnsViewResult_WhenAluguerExists()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Aluguer>(
                viewResult.ViewData.Model);
            Assert.NotNull(model);

            // Estes testes deveriam estar separados em diferentes métodos de teste!
            var viewdata1 = controller.ViewData["CarroId"];
            Assert.NotNull(viewdata1);
            Assert.IsType<SelectList>(viewdata1);
            Assert.True((viewdata1 as SelectList).Count() > 0);

            var viewdata2 = controller.ViewData["UserId"];
            Assert.NotNull(viewdata2);
            Assert.IsType<SelectList>(viewdata2);
            Assert.True((viewdata2 as SelectList).Count() > 0);
        }


        [Fact]
        public async Task EditPost_ReturnsNotFoundResult_WhenIdDoesntMatchAluguerId()
        {
            var controller = new AlugueresController(_context);
            Aluguer aluguer = _context.Aluguer.FirstOrDefault(a => a.AluguerId == 1);

            var result = await controller.Edit(2, aluguer);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnsNotFoundResult_WhenAluguerDoesntExist()
        {
            var controller = new AlugueresController(_context);

            var result = await controller.Edit(6, new Aluguer { AluguerId = 6 });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task EditPost_ReturnsViewResult_WhenModelStateIsInValid()
        {
            var controller = new AlugueresController(_context);
            Aluguer aluguer = _context.Aluguer.FirstOrDefault(a => a.AluguerId == 1);
            controller.ModelState.AddModelError("Erro", "Erro adicionado para teste");

            var result = await controller.Edit(1, aluguer);

            Assert.IsType<ViewResult>(result);

            // Estes testes deveriam estar separados em diferentes métodos de teste!
            var viewdata1 = controller.ViewData["CarroId"];
            Assert.NotNull(viewdata1);
            Assert.IsType<SelectList>(viewdata1);
            Assert.True((viewdata1 as SelectList).Count() > 0);

            var viewdata2 = controller.ViewData["UserId"];
            Assert.NotNull(viewdata2);
            Assert.IsType<SelectList>(viewdata2);
            Assert.True((viewdata2 as SelectList).Count() > 0);
        }

        [Fact]
        public async Task EditPost_ReturnsRedirectToActionResult_WhenAluguerIsUpdated()
        {
            var controller = new AlugueresController(_context);
            Aluguer aluguer = _context.Aluguer.FirstOrDefault(a => a.AluguerId == 5);
            aluguer.LocalDeEntrega += "N";

            var result = await controller.Edit(5, aluguer);

            Assert.IsType<RedirectToActionResult>(result);
            Aluguer aluguerUpdated = _context.Aluguer.FirstOrDefault(a => a.AluguerId == 5);
            Assert.Equal(aluguer.LocalDeEntrega, aluguerUpdated.LocalDeEntrega);
        }
    }
}
