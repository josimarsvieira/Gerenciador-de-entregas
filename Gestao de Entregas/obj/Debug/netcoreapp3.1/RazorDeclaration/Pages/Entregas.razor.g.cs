#pragma checksum "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bb79ceec894b6df56bb1013d887bd8d2181e42f"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Gestao_de_Entregas.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Gestao_de_Entregas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\_Imports.razor"
using Gestao_de_Entregas.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor"
using Gestao_de_Entregas.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/entregas")]
    public partial class Entregas : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 232 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Entregas.razor"
 
    public List<EntregaUrgente> ListaEntregasUrgente;
    public List<EntregaUrgente> ListaResumida;
    public List<EntregaUrgenteStatus> ListaEntregaUrgenteStatus;

    public StringBuilder strNotas = new StringBuilder();
    ClaimsPrincipal UsuarioAtual;
    ApplicationUser Usuario;

    EntregaUrgente objEntregas = new EntregaUrgente();
    EntregaUrgenteStatus objEntregaUrgenteStatus = new EntregaUrgenteStatus();

    public string strError = "";
    int pagina;

    // Habilita a exibição do Popup
    bool MostraPopup = false;
    bool MostraPopupView = false;
    bool MostraStatusPopup = false;

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private void AdicionarEntrega()
    {
        objEntregas = new EntregaUrgente();
        MostraPopup = true;
    }

    private void MarcarUrgente(EntregaUrgente entrega)
    {
        try
        {
            entrega.Urgente = true;
            objGerenciadorService.AtualizarEntrega(entrega);

            objEntregaUrgenteStatus = new EntregaUrgenteStatus { EntregaUrgente = entrega, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Entrega foi marcada como urgente" };
            objGerenciadorService.InserirEntregaUrgenteStatus(objEntregaUrgenteStatus);

        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        BuscarEntregas();
    }

    private void MarcaRetira(EntregaUrgente entrega)
    {
        try
        {
            entrega.Retira = true;
            objGerenciadorService.AtualizarEntrega(entrega);

            objEntregaUrgenteStatus = new EntregaUrgenteStatus { EntregaUrgente = entrega, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Entrega foi marcada como retira na filial" };
            objGerenciadorService.InserirEntregaUrgenteStatus(objEntregaUrgenteStatus);

        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        BuscarEntregas();
    }

    private void MarcarEntregue(EntregaUrgente entrega)
    {
        try
        {
            entrega.Entregue = true;
            objGerenciadorService.AtualizarEntrega(entrega);

            objEntregaUrgenteStatus = new EntregaUrgenteStatus { EntregaUrgente = entrega, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Entrega foi concluída" };
            objGerenciadorService.InserirEntregaUrgenteStatus(objEntregaUrgenteStatus);

        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        BuscarEntregas();

    }

    private void SalvaUrgencia()
    {
        try
        {
            objEntregas.Usuario = Usuario;
            objEntregas.DataSolicitacao = DateTime.Now;
            objGerenciadorService.AtualizarEntrega(objEntregas);

            objEntregaUrgenteStatus = new EntregaUrgenteStatus { EntregaUrgente = objEntregas, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Solicitação de entrega registrada" };
            objGerenciadorService.InserirEntregaUrgenteStatus(objEntregaUrgenteStatus);

            MostraPopup = false;
        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        BuscarEntregas();

    }

    private void BuscarEntregasUrgenteStatus(EntregaUrgente entrega)
    {
        ListaEntregaUrgenteStatus = objGerenciadorService.ObterEntregaUrgenteStatus(entrega);
        MostraStatusPopup = true;
    }

    private void FechaStatusPopup()
    {
        MostraStatusPopup = false;
    }

    private void BuscarEntregas()
    {
        pagina = 0;
        ListaEntregasUrgente = new List<EntregaUrgente>();
        strError = "";

        try
        {
            ListaEntregasUrgente = objGerenciadorService.ObterEntregas();
        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        ProximaPagina();
    }

    private void ProximaPagina()
    {
        ListaResumida = new List<EntregaUrgente>();
        int count = ListaEntregasUrgente.Count;
        pagina += 8;

        for (int i = 0; i < ListaEntregasUrgente.Count && i < pagina; i++)
        {
            ListaResumida.Add(ListaEntregasUrgente[i]);
        }
    }

    private void MostrarDetalhes(EntregaUrgente entrega)
    {
        objEntregas = entrega;
        MostraPopupView = true;
    }

    public void FechaPopup()
    {
        // fecha o popup
        MostraPopup = false;
        MostraPopupView = false;
        BuscarEntregas();
    }

    protected override async Task OnInitializedAsync()
    {
        BuscarEntregas();
        UsuarioAtual = (await authenticationStateTask).User;
        var usuario = await _UserManager.FindByEmailAsync(UsuarioAtual.Identity.Name);
        Usuario = usuario;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<ApplicationUser> _UserManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private GerenciadorService objGerenciadorService { get; set; }
    }
}
#pragma warning restore 1591
