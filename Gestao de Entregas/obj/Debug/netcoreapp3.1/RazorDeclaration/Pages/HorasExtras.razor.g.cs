#pragma checksum "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5840c47f6df9b17d1fcf79fd3ae673f688bcc4e"
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
#line 3 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
using Gestao_de_Entregas.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/horasextras")]
    public partial class HorasExtras : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 206 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
       
    List<Funcionario> objFuncionarios;
    List<HorasFuncionario> objHorasDoFuncionario;
    List<HorasFuncionario> objHorasDoFuncionario2;
    Funcionario objFuncionario;
    List<BancoDeHoras> objBanco;
    DateTime selecionada = new DateTime();
    DateTime selecionadaAnterior = new DateTime();
    TimeSpan totalHoras;
    TimeSpan totalHorasAnterior;

    List<int> Mes = new List<int>() { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
    List<int> Ano = new List<int>() { 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027 };
    List<string> Nome = new List<string>();
    static int _diaFechamento = 26;
    int _ano = DateTime.Now.Year;
    int _mes = DateTime.Now.Month;
    int _idFuncionario;
    bool MostraBancoPopup = false;
    ClaimsPrincipal UsuarioAtual;
    ApplicationUser Usuario;
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    private void BuscarFuncionarios()
    {
        objFuncionarios = objDabaseContext.BuscarFuncionario();
    }

    private void BuscaHorasFuncionario()
    {
        objFuncionario = objFuncionarios.Where(x => x.Id == _idFuncionario).SingleOrDefault();
        objHorasDoFuncionario = objDabaseContext.BuscaCartaoPonto(objFuncionario, new DateTime(_ano, _mes, _diaFechamento));
    }

    private string MesExtenso(int _Mes)
    {
        string mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(_Mes).ToLower();
        mes = char.ToUpper(mes[0]) + mes.Substring(1);
        return mes;
    }

    private void BuscaHorasFuncionarioFiltrado()
    {
        //DateTime selecionada = new DateTime(_ano, _mes, _diaFechamento);
        selecionada = new DateTime(_ano, _mes, _diaFechamento);
        selecionadaAnterior = new DateTime(_mes == 1 ? _ano - 1 : _ano, _mes == 1 ? 12 : _mes - 1, _diaFechamento);

        objHorasDoFuncionario = objDabaseContext.BuscaCartaoPonto(objFuncionario, selecionada.AddDays(-1),
        new DateTime(selecionada.Month == 1 ? selecionada.Year - 1 : selecionada.Year, selecionada.Month == 1 ? 12 : selecionada.Month - 1, _diaFechamento));

        objHorasDoFuncionario2 = objDabaseContext.BuscaCartaoPonto(objFuncionario, selecionadaAnterior.AddDays(-1),
        new DateTime(selecionadaAnterior.Month == 1 ? selecionadaAnterior.Year - 1 : selecionadaAnterior.Year, selecionadaAnterior.Month == 1 ? 12 : selecionadaAnterior.Month - 1, _diaFechamento));

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 260 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
         if (objHorasDoFuncionario != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 262 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
             foreach (HorasFuncionario horas in objHorasDoFuncionario)
            {
                totalHoras += horas.Extras;
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 265 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
             
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 268 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
         if (objHorasDoFuncionario2 != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 270 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
             foreach (HorasFuncionario horas in objHorasDoFuncionario2)
            {
                totalHorasAnterior += horas.Extras;
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 273 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
             
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 274 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\HorasExtras.razor"
         

    }

    private void FechaPopup()
    {
    }

    private string TotalHorasExtenso(TimeSpan total)
    {
        int dias = 0;
        TimeSpan _total = total;

        while (_total > new TimeSpan(8, 48, 0))
        {
            dias++;
            _total -= new TimeSpan(8, 48, 0);
        }

        return $"{dias} dia(s), {total.Hours} horas e {total.Minutes} minutos!!";
    }

    private string BuscaBancoDeHoras()
    {
        objBanco = objDabaseContext.BuscaBancoDeHoras(objFuncionario);
        TimeSpan total = new TimeSpan();
        int dias = 0;

        foreach (BancoDeHoras banco in objBanco)
        {
            total += banco.HorasExtras;
        }

        while (total > new TimeSpan(8, 48, 0))
        {
            dias++;
            total -= new TimeSpan(8, 48, 0);
        }

        return $"{dias} dias, {total.Hours} horas e {total.Minutes} minutos de";
    }

    protected override async Task OnInitializedAsync()
    {
        BuscarFuncionarios();
        UsuarioAtual = (await authenticationStateTask).User;
        var usuario = await _UserManager.FindByEmailAsync(UsuarioAtual.Identity.Name);
        Usuario = usuario;
        objFuncionario = objFuncionarios.Where(x => x.Nome.ToUpper() == Usuario.Name.ToUpper()).FirstOrDefault();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<ApplicationUser> _UserManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private CalculadorService objDabaseContext { get; set; }
    }
}
#pragma warning restore 1591