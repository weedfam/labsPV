using System;
using System.Collections.Generic;
using System.Linq;

namespace AnaliseProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> produtos = Produtos.Obter();

            Console.WriteLine("Lista de Produtos: \n");
            produtos.ForEach(p => Console.WriteLine("{0:00} - {1}", p.ProductId, p.ProductName));

            // Testes LinQ


            //Nivel 1:
            Console.Clear();
            Console.WriteLine("\n NIVEL 1 ------- Lista de bebidas");
            var bebidas = from produto in produtos where produto.Category == "Beverages" orderby produto.ProductName select produto;
            foreach (var bebida in bebidas)
                Console.WriteLine(bebida);

            Console.WriteLine("\n NIVEL 1 ------- Produtos começados por 'l'");
            var produtosComecadosPorL = from produto in produtos where produto.ProductName.ToLower().StartsWith("l") select produto;
            foreach (Product produto in produtosComecadosPorL)
                Console.WriteLine(produto);

            Console.WriteLine("\n NIVEL 1 ------- Bebidas começadas por 'l'");
            var bebidasComecadasPorL = from produto in produtosComecadosPorL where produto.Category == "Beverages" select produto;
            foreach (Product produto in bebidasComecadasPorL)
                Console.WriteLine(produto);

            Console.ReadKey();


            //Nivel 2:
            Console.Clear();
            Console.WriteLine("\n NIVEL 2 ------- Bebidas entre os 10€ e os 25€");
            var bebidasEntre10e25 = from bebida in bebidas
                                    where bebida.UnitPrice >= 10.0M && bebida.UnitPrice <= 25.00M
                                    select bebida;

            foreach (var bebida in bebidasEntre10e25)
                Console.WriteLine("> " + bebida);

            produtos.Add(new Product
            {
                ProductId = 78,
                ProductName = "Heineken",
                Category = "Beverages",
                UnitPrice = 15.4000M,
                UnitsInStock = 20
            });

            produtos.Add(new Product
            {
                ProductId = 79,
                ProductName = "Super Bock",
                Category = "Beverages",
                UnitPrice = 10.5000M,
                UnitsInStock = 10
            });

            Console.WriteLine("\n NIVEL 2 ------- Bebidas entre os 10€ e os 25€ (repetição)");
            foreach (var bebida in bebidasEntre10e25)
                Console.WriteLine("> " + bebida);

            Console.WriteLine("\n NIVEL 2 ------- Bebida com o product ID mais baixo");
            int minProductIdBebidas = (from bebida in bebidas select bebida.ProductId).Min();
            Product bebidaMinProductId = (from bebida in bebidas where bebida.ProductId == minProductIdBebidas select bebida).FirstOrDefault();
            Console.WriteLine("> " + bebidaMinProductId.ProductName + " (" + bebidaMinProductId + ")");


            // Nivel 3
            Console.Clear();
            Console.WriteLine("\n NIVEL 3 ------- Valor total das bebidas em stock");
            var bebidasValorTotal = from bebida in bebidas
                                    select new
                                    {
                                        Nome = bebida.ProductName,
                                        Quantidade = bebida.UnitsInStock,
                                        ValorTotal = bebida.UnitPrice * bebida.UnitsInStock
                                    };

            foreach (var bebida in bebidasValorTotal)
                Console.WriteLine("{0} ({1,2} unidades) - {2:0.00}", bebida.Nome, bebida.Quantidade, bebida.ValorTotal);
            var valorTotal = (from bebida in bebidasValorTotal select bebida.ValorTotal).Sum();
            Console.WriteLine("\nTotal das bebidas em stock: {0:0.00}", valorTotal);

            Console.WriteLine("\n NIVEL 3 ------- Bebida mais cara");
            var precos = from bebida in bebidas select bebida.UnitPrice;
            var maisCaro = from bebida in bebidas where bebida.UnitPrice == precos.Max() select bebida;
            Console.WriteLine(maisCaro.First());

            Console.WriteLine("\n NIVEL 3 ------- Bebida mais barata");
            var maisBarato = from bebida in bebidas where bebida.UnitPrice == precos.Min() select bebida;
            Console.WriteLine(maisBarato.First());

            Console.WriteLine("\n NIVEL 3 ------- Preço médio das bebidas");
            Console.WriteLine("Media: {0:0.00}", precos.Average());

            Console.ReadKey();


            //Nivel 4
            Console.Clear();
            Console.WriteLine("\n NIVEL 4 ------- Produtos ordenados pelo nome");
            List<Product> produtosNomeAscendente = produtos.OrderBy(produto => produto.ProductName).ToList();
            foreach (var produto in produtosNomeAscendente)
                Console.WriteLine(produto);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n NIVEL 4 ------- Categorias");
            List<string> categorias = produtos
                .Select(produto => produto.Category)
                .Distinct()
                .ToList();
            foreach (var categoria in categorias)
                Console.WriteLine("> " + categoria);

            Console.WriteLine("\n NIVEL 4 ------- Lista de produtos abaixo dos 10€");
            bool existemProdutosAbaixo10 = produtos.Any(produto => produto.UnitPrice < 10);
            Console.WriteLine((existemProdutosAbaixo10 ? "" : "Não ") + "existem produtos que custam menos de 10€");

            Console.WriteLine("\n NIVEL 4 ------- Número médio de unidades em stock");
            var mediaUnidadesEmStock = produtos.Average(produto => produto.UnitsInStock);
            Console.WriteLine(mediaUnidadesEmStock);

            Console.ReadKey();
            // Nivel 5
            Console.Clear();
            Console.WriteLine("\n NIVEL 5 ------- Produtos abaixo de 100€ (1º a 5º)");
            var produtosAbaixo100 = produtos
                .Where(produto => produto.UnitPrice < 100.0M)
                .OrderBy(produto => produto.UnitPrice)
                .Take(5);
            foreach (var product in produtosAbaixo100)
                Console.WriteLine("> " + product);

            Console.WriteLine("\n NIVEL 5 ------- Produtos abaixo de 100€ (6º a 10º)");
            List<Product> produtosAbaixo100n6a10 = produtos
                 .Where(produto => produto.UnitPrice < 100.0M)
                 .OrderBy(produto => produto.UnitPrice)
                 .Skip(5)
                 .Take(5)
                 .ToList();
            foreach (var produto in produtosAbaixo100n6a10)
                Console.WriteLine("> " + produto);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n NIVEL 5 ------- produtos ordenados pela categoria e pelo nome");
            List<Product> produtosPorCategoriaDepoisPorNome = produtos
                .OrderBy(produto => produto.Category)
                .ThenBy(produto => produto.ProductName)
                .ToList();
            foreach (var produto in produtosPorCategoriaDepoisPorNome)
                Console.WriteLine("> " + produto);

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\n Desafio ------- Produtos agrupados por categoria");
            var produtosAgrupadosPorCategoria = produtos.GroupBy(produto => produto.Category);
            foreach (var grupo in produtosAgrupadosPorCategoria)
            {
                Console.WriteLine(grupo.Key);
                foreach (var produto in grupo)
                    Console.WriteLine("{0:00} - {1:000} - {2:000.00} {3}", produto.ProductId, produto.UnitsInStock, produto.UnitPrice, produto.ProductName);
            }

            Console.ReadLine();
        }
    }
}
