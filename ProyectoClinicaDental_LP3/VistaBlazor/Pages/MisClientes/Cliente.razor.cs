using VistaBlazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace VistaBlazor.Pages.MisClientes
{
    public partial class Cliente
    {
        [Inject] private IClienteServicio clienteServicio{ get; set; }

        private IEnumerable<ClienteM> listaC { get; set; }

     /*   protected override async Task OnInitializedAsync()
        {
            listaC = await clienteServicio.GetListaClienteAsync();
        }*/
    }
}
