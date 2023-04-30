using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisClientes
{
    public partial class Cliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        private IEnumerable<ClienteM> listaClientes { get; set; }

    /*   protected override async Task OnInitializedAsync()
        {
            listaClientes = await clienteServicio.GetListaClienteAsync();
        }*/
    }
}
