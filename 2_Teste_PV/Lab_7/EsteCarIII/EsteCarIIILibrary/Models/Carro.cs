using System.ComponentModel.DataAnnotations;

namespace EsteCarIIILibrary.Models
{
    public class Carro
    {
        // Chave primária
        public int CarroId { get; set; }

        // Chave estrangeira
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(25, ErrorMessage = "O {0} não deve ter mais de {1} caracteres")]
        public string Modelo { get; set; }

        [Display(Name = "Número de Portas")]
        [Required(ErrorMessage = "O numero de portas é obrigatório")]
        [Range(1, 5, ErrorMessage = "O valor para o {0} tem que estar entre {1} e {2}")]
        public int NumeroDePortas { get; set; }

        [Display(Name = "Tipo de Caixa")]
        public string TipoDeCaixa { get; set; }

        [StringLength(255)]
        public string FicheiroFoto { get; set; }

        // Propriedade navegacional
        public Marca Marca { get; set; }
    }
}
