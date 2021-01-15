using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSistemasCRUDCompleto.Models
{
    [Table("grupoprodutos")]
    public class GrupoDeProdutos
    {
        [Key]
        public int Codigo { get; set;}

        public string Descricao { get; set; }

        public bool Status { get; set; }

    }
}
