using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediESTeca.Models
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Isbn { get; set; }
        public int AnoEdicao { get; set; }
        public bool EmDestaque { get; set; }
    }
}
