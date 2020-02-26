#pragma checksum "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fbf7f38c787fe8c78383e8465ea1005ee6fde6f"
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
#line 4 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor"
using Gestao_de_Entregas.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor"
           [Authorize(Roles = "Admin")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/administrador")]
    public partial class Administrador : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 128 "C:\Users\josim\source\Gerenciador de entregas\Gestao de Entregas\Pages\Administrador.razor"
       

    // Propriedade usada para adicionar ou editar o usuário atual
    ApplicationUser objUser = new ApplicationUser();

    // Obtem a role selecionada para o usuário atual
    string CurrentUserRole { get; set; } = "User";

    // Coleção para exibir os usuários existentes
    List<ApplicationUser> ColUsers = new List<ApplicationUser>();

    // Opções para exibir as roles na lista suspensa quando editar um usuário
    List<string> Options = new List<string>() { "User", "Admin" };

    List<string> Filiais = new List<string>() { "Matriz", "Curitiba", "Ubá", "Rio de Janeiro", "Arapongas", "Linhares", "São bento do sul" };

    // Trata erros
    string strError = "";

    // Habilita a exibição do Popup
    bool MostraPopup = false;

    void AdicionaNovoUser()
    {
        // cria um novo usuário
        objUser = new ApplicationUser();
        objUser.PasswordHash = "*****";
        // Definie o id como vazio
        objUser.Id = "";
        // abre o popup
        MostraPopup = true;
    }

    async Task SalvaUser()
    {
        try
        {
            // É um usuário existente?
            if (objUser.Id != "")
            {
                // obtem o usuário
                var user = await _UserManager.FindByIdAsync(objUser.Id);
                // atualiza Email
                user.Email = objUser.Email;
                user.UserName = objUser.Email;
                // atualiza o usuário
                await _UserManager.UpdateAsync(user);
                // somente atualiza a senha se o o valor atual
                // não for o valor padrão
                if (objUser.PasswordHash != "*****")
                {
                    var resetToken = await _UserManager.GeneratePasswordResetTokenAsync(user);
                    var passworduser = await _UserManager.ResetPasswordAsync(user, resetToken, objUser.PasswordHash);
                    if (!passworduser.Succeeded)
                    {
                        if (passworduser.Errors.FirstOrDefault() != null)
                        {
                            strError = passworduser.Errors.FirstOrDefault().Description;
                        }
                        else
                        {
                            strError = "Erro na senha...";
                        }
                        // mantem o popup aberto
                        return;
                    }
                }
                // trata os perfis
                // O usuário esta no perfil admin ?
                var UserResult = await _UserManager.IsInRoleAsync(user, ADMINISTRATION_ROLE);
                // O perfil Administrator foi selecionado
                // mas o usuário náo é um  Administrator?
                if ((CurrentUserRole == ADMINISTRATION_ROLE) & (!UserResult))
                {
                    // Poe o admin no perfil Administrator
                    await _UserManager.AddToRoleAsync(user, ADMINISTRATION_ROLE);
                }
                else
                {
                    // O perifl Administrator não foi selecionado
                    // mas o usuário é um Administrator ?
                    if ((CurrentUserRole != ADMINISTRATION_ROLE) & (UserResult))
                    {
                        // Remove o usuário do perfil Administrator
                        await _UserManager.RemoveFromRoleAsync(user, ADMINISTRATION_ROLE);
                    }
                }
            }
            else
            {
                // Insere um novo user
                var NewUser = new ApplicationUser
                {
                    Name = objUser.Name,
                    Cargo = objUser.Cargo,
                    Filial = objUser.Filial,
                    UserName = objUser.Email,
                    Email = objUser.Email
                };

                var CreateResult = await _UserManager.CreateAsync(NewUser, objUser.PasswordHash);

                if (!CreateResult.Succeeded)
                {
                    if (CreateResult.Errors.FirstOrDefault() != null)
                    {
                        strError = CreateResult.Errors.FirstOrDefault().Description;
                    }
                    else
                    {
                        strError = "Erro ao criar usuário...";
                    }
                    // mantem o popup aberto
                    return;

                }
                else
                {
                    // Trata os perfis
                    if (CurrentUserRole == ADMINISTRATION_ROLE)
                    {
                        // poe o admin no perfil Administrator
                        await _UserManager.AddToRoleAsync(NewUser, ADMINISTRATION_ROLE);
                    }
                }
            }
            // fecha o Popup
            MostraPopup = false;
            // Atualiza os usuarios
            GetUsers();
        }
        catch (Exception ex)
        {
            strError = ex.GetBaseException().Message;
        }
    }

    async Task EditaUser(ApplicationUser _ApplicationUser)
    {
        // Define o usuario selecionado como o atual
        objUser = _ApplicationUser;
        // Obtem o usuario
        var user = await _UserManager.FindByIdAsync(objUser.Id);

        if (user != null)
        {
            // O usuario esta no perfiel administrator ?
            var UserResult = await _UserManager.IsInRoleAsync(user, ADMINISTRATION_ROLE);

            if (UserResult)
            {
                CurrentUserRole = ADMINISTRATION_ROLE;
            }
            else
            {
                CurrentUserRole = "User";
            }
        }
        // Abre o popup
        MostraPopup = true;
    }

    async Task DeletaUser()
    {
        // Fecha o Popup
        MostraPopup = false;
        // Obtem o usuário
        var user = await _UserManager.FindByIdAsync(objUser.Id);
        if (user != null)
        {
            // Deleta o usuario
            await _UserManager.DeleteAsync(user);
        }
        // atualiza
        GetUsers();
    }

    void FechaPopup()
    {
        // fecha o popup
        MostraPopup = false;
    }

    public void GetUsers()
    {
        // limpa mensasgens de erro
        strError = "";
        // define a coleção para tratar os usuários
        ColUsers = new List<ApplicationUser>();
        // Obtem os usuários a partir de _UserManager
        var user = _UserManager.Users.Select(x => new ApplicationUser
        {
            Id = x.Id,
            Name = x.Name,
            Cargo = x.Cargo,
            Filial = x.Filial,
            UserName = x.UserName,
            Email = x.Email,
            PasswordHash = "*****"
        });
        foreach (var item in user)
        {
            ColUsers.Add(item);
        }
    }

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }

    string ADMINISTRATION_ROLE = "Admin";

    System.Security.Claims.ClaimsPrincipal UsuarioAtual;

    protected override async Task OnInitializedAsync()
    {
        // Verifica se existe um ADMINISTRATION_ROLE
        var RoleResult = await _RoleManager.FindByNameAsync(ADMINISTRATION_ROLE);
        if (RoleResult == null)
        {
            // Cria o perfil ADMINISTRATION_ROLE
            await _RoleManager.CreateAsync(new IdentityRole(ADMINISTRATION_ROLE));
        }
        // Verifica que o usuário chamado Admin@BlazorHelp.com é um Administrador
        var user = await _UserManager.FindByEmailAsync("josimarsv@outlook.com");
        if (user != null)
        {
            // O usuário Admin@BlazorHelp.com esta no perfil de administrador?
            var UserResult = await _UserManager.IsInRoleAsync(user, ADMINISTRATION_ROLE);
            if (!UserResult)
            {
                // Põe o admin no perfil Administrator
                await _UserManager.AddToRoleAsync(user, ADMINISTRATION_ROLE);
            }
        }
        // Obtem o usuário logado atual
        UsuarioAtual = (await authenticationStateTask).User;

        GetUsers();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private RoleManager<IdentityRole> _RoleManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UserManager<ApplicationUser> _UserManager { get; set; }
    }
}
#pragma warning restore 1591
