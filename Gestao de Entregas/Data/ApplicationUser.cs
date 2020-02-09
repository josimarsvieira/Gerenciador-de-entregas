using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_de_Entregas.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Filial { get; set; }
        public string Cargo { get; set; }
    }
}