using System;
using System.ComponentModel.DataAnnotations;

namespace Gestao_de_Entregas.Data
{
    public class Coleta
    {
        [Key]
        public int ColetaId { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [Required]
        public string Solicitante { get; set; }

        public int Volumes { get; set; }
        public double Metragem { get; set; }
        public double Peso { get; set; }

        [Required]
        public DateTime DataColeta { get; set; }

        [Required]
        public DateTime DataSolicitacao { get; set; }

        [Required]
        public bool Coletado { get; set; }

        [Required]
        public bool Cancelado { get; set; }

        public string Observacoes { get; set; }

        [Required]
        public ApplicationUser Usuario { get; set; }

        public Coleta()
        {
        }
    }
}