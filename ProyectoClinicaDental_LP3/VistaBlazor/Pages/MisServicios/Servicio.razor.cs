using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisServicios
{
    public partial class Servicio
    {
        [Inject] IServicioServicio ServicioServicio { get; set; }

        IEnumerable<ServicioM> listaServicios { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaServicios = await ServicioServicio.GetLista();
        }

    }
}
