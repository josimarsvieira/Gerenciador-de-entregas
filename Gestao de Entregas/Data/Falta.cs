using System;
using System.ComponentModel.DataAnnotations;

namespace Gestao_de_Entregas.Data
{
    public class Falta
    {
        [Key]
        public int FaltaId { get; set; }

        [Required]
        public string Remetente { get; set; }

        [Required]
        public string Destinatario { get; set; }

        [Required]
        public int NumeroNota { get; set; }

        [Required]
        public int NumeroCTE { get; set; }

        [Required]
        public int VolumesFaltante { get; set; }

        [Required]
        public bool Encontrado { get; set; }

        [Required]
        public ApplicationUser Usuario { get; set; }

        [Required]
        public DateTime DataFalta { get; set; }
    }
}