using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Entregas.Data
{
    public class EntregaUrgenteStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public EntregaUrgente EntregaUrgente { get; set; }

        [Required]
        public string Observacao { get; set; }

        [Required]
        public IdentityUser Usuario { get; set; }

        [Required]
        public DateTime DataStatus { get; set; }
    }
}