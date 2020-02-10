using System;
using System.ComponentModel.DataAnnotations;

namespace Gestao_de_Entregas.Data
{
    public class FaltaStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Falta Falta { get; set; }

        [Required]
        public string Observacao { get; set; }

        [Required]
        public DateTime DataStatus { get; set; }

        [Required]
        public ApplicationUser Usuario { get; set; }
    }
}