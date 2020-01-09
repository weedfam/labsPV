using System.Linq;
using System.Threading.Tasks;
using EsteCarIIILibrary.Models;

namespace EsteCarIIILibrary.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if ( /*NOT*/ !context.Marca.Any())
            {
                // Adicionar Marcas para testes
                context.Marca.Add(new Marca { Designacao = "Ferrary" });
                context.Marca.Add(new Marca { Designacao = "Porche" });
                context.Marca.Add(new Marca { Designacao = "BMW" });
                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }

            if (/* NOT */ !context.Carro.Any())
            {
                //context.Carros.Add(new Carro {MarcaId= 1 , Modelo="TestaRossa", NumeroDePassageiros=2, NumeroDePortas=2, TipoDeCaixa="Manual" });
                context.Carro.Add(new Carro { MarcaId = (context.Marca.First(m => m.Designacao.Contains("Ferrary"))).MarcaId, Modelo = "TestaRossa", NumeroDePortas = 2, TipoDeCaixa = "Manual" });
                context.Carro.Add(new Carro { MarcaId = (context.Marca.First(m => m.Designacao.Contains("Porche"))).MarcaId, Modelo = "911 Carrera", NumeroDePortas = 2, TipoDeCaixa = "Manual" });
                context.SaveChanges();
            }
        }
    }
}
