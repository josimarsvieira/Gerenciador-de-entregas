using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestao_de_Entregas.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}