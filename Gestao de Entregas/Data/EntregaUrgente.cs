using System;
using System.ComponentModel.DataAnnotations;

namespace Gestao_de_Entregas.Data
{
    public class EntregaUrgente
    {
        [Key]
        public int EntregaId { get; set; }

        [Required]
        public string Remetente { get; set; }

        [Required]
        public string Destinatario { get; set; }

        [Required]
        public string Solicitante { get; set; }

        [Required]
        public DateTime DataSolicitacao { get; set; }

        public bool Entregue { get; set; }

        [Required]
        public ApplicationUser Usuario { get; set; }

        public string Observacoes { get; set; }

        public bool Urgente { get; set; }

        public bool Retira { get; set; }

        [Required]
        public int Nota { get; set; }

        public EntregaUrgente()
        {
        }
    }
}