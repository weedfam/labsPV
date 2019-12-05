using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESTaPapelaria.Models
{
    public class Artigo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }
        public bool EmPromocao { get; set; }
    }
}
