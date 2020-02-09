#pragma checksum "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75a715591a351b1f402178963819a041726e6232"
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
#line 1 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Gestao_de_Entregas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\_Imports.razor"
using Gestao_de_Entregas.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor"
using Gestao_de_Entregas.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/coletas")]
    public partial class Coletas : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 168 "C:\Users\josim\source\Gerenciador de Entregas\Gestao de Entregas\Pages\Coletas.razor"
 
    public List<Coleta> ListaColeta;
    public List<Coleta> ListaResumida;
    public List<ColetaStatus> ListaColetaStatus;

    ClaimsPrincipal UsuarioAtual;
    IdentityUser Usuario;

    Coleta objcoleta = new Coleta();
    ColetaStatus objColetaStatus = new ColetaStatus();
    public string strError = "";
    int pagina;

    // Habilita a exibição do Popup
    bool MostraPopup = false;
    bool MostraStatusPopup = false;

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private void AdicionarColeta()
    {
        objcoleta = new Coleta();
        MostraPopup = true;
    }

    private void MarcarCancelado(Coleta coleta)
    {
        try
        {
            coleta.Cancelado = true;
            objGerenciadorService.AtualizarColeta(coleta);

            objColetaStatus = new ColetaStatus { Coleta = coleta, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Coleta foi cancelada" };
            objGerenciadorService.InserirColetaStatus(objColetaStatus);

        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        Buscarcoleta();
    }

    private void MarcarColetado(Coleta coleta)
    {
        try
        {
            coleta.Coletado = true;
            objGerenciadorService.AtualizarColeta(coleta);

            objColetaStatus = new ColetaStatus { Coleta = coleta, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Coleta Realizada" };
            objGerenciadorService.InserirColetaStatus(objColetaStatus);
        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        Buscarcoleta();

    }

    private void SalvaColeta()
    {
        try
        {
            objcoleta.Usuario = Usuario;
            objcoleta.DataSolicitacao = DateTime.Now;

            if (objcoleta.ColetaId == 0)
            {
                objColetaStatus = new ColetaStatus { Coleta = objcoleta, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Solicitação de coleta realizada" };
            }
            else
            {
                objColetaStatus = new ColetaStatus { Coleta = objcoleta, DataStatus = DateTime.Now, Usuario = this.Usuario, Observacao = "Solicitação de coleta alterada" };
            }

            objGerenciadorService.AtualizarColeta(objcoleta);
            objGerenciadorService.InserirColetaStatus(objColetaStatus);

            MostraPopup = false;
        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        Buscarcoleta();

    }

    private void BuscarColetaStatus(Coleta coleta)
    {
        ListaColetaStatus = objGerenciadorService.ObterColetaStatus(coleta);
        MostraStatusPopup = true;
    }

    private void Buscarcoleta()
    {
        pagina = 0;
        ListaColeta = new List<Coleta>();
        strError = "";

        try
        {
            ListaColeta = objGerenciadorService.ObterColeta();
        }
        catch (Exception ex)
        {
            strError = ex.Message.ToString();
        }

        ProximaPagina();
    }

    private void ProximaPagina()
    {
        ListaResumida = new List<Coleta>();
        int count = ListaColeta.Count;
        pagina += 10;

        for (int i = 0; i < ListaColeta.Count && i < pagina; i++)
        {
            ListaResumida.Add(ListaColeta[i]);
        }
    }

    private void MostrarDetalhes(Coleta coleta)
    {
        objcoleta = coleta;
        MostraPopup = true;
    }

    public void FechaPopup()
    {
        // fecha o popup
        MostraPopup = false;
        Buscarcoleta();
    }

    public void FechaStatusPopup()
    {
        MostraStatusPopup = false;
    }

    protected override async Task OnInitializedAsync()
    {
        Buscarcoleta();
        UsuarioAtual = (await authenticationStateTask).User;
        var usuario = await _UserManager.FindByEmailAsync(UsuarioAtual.Identity.Name);
        Usuario = usuario;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<IdentityUser> _UserManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private GerenciadorService objGerenciadorService { get; set; }
    }
}
#pragma warning restore 1591