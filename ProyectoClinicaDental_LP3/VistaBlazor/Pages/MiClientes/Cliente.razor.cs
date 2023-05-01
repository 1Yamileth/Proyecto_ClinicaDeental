using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MiClientes
{
    public partial class Cliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }

        private IEnumerable<ClienteM> listaC { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaC = await clienteServicio.GetListaClienteAsync();
        }
    }
}
