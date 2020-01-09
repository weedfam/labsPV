using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EsteCarIIILibrary.Models
{
    public class Marca
    {
        // Chave primária
        public int MarcaId { get; set; }

        [Display(Name = "Designação")]
        [Required(ErrorMessage = "A {0} é obrigatória")]
        [StringLength(20, ErrorMessage = "A {0} não deve ter mais do que {1} caracteres")]
        public string Designacao { get; set; }

        // Propriedade Navegacional
        public List<Carro> Carros { get; set; }


    }
}

