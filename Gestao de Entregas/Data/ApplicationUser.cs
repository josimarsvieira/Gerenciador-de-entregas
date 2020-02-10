using Microsoft.AspNetCore.Identity;

namespace Gestao_de_Entregas.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Filial { get; set; }
        public string Cargo { get; set; }
    }
}