using Microsoft.AspNetCore.Components;

namespace Gestao_de_Entregas.Data
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}