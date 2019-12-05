using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseProdutos
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public override string ToString()
        {
            return String.Format("{0:00} - {1:000} - {2:000.00} \t {3,-15} \t {4}", ProductId, UnitsInStock, UnitPrice, Category, ProductName);
        }
    }
}
