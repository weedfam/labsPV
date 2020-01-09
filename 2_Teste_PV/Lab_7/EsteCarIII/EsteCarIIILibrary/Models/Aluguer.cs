using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EsteCarIIILibrary.Data;

namespace EsteCarIIILibrary.Models
{
    public class Aluguer
    {
        public int AluguerId { get; set; }

        [Display(Name = "Carro")]
        public int CarroId { get; set; }

        [Display(Name = "Cliente")]
        [ForeignKey("Cliente")]
        public string UserId { get; set; }

        [Display(Name = "Local de entrega")]
        public String LocalDeEntrega { get; set; }

        [Display(Name = "Local de recolha")]
        public String LocalDeRecolha { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de ínicio")]
        [NotWeekend(ErrorMessage = "Não pode alugar neste dia")]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de fim")]
        public DateTime DataFim { get; set; }

        public Carro Carro { get; set; }
        public Cliente Cliente { get; set; }
    }
}
