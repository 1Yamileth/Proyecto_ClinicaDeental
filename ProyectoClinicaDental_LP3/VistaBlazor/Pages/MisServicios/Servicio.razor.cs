using Microsoft.AspNetCore.Components;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisServicios
{
    public partial class Servicio
    {
        [Inject] IServicioServicio ServicioServicio { get; set; }

        IEnumerable<Servicio> listaServicios { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaServicios = (IEnumerable<Servicio>)await ServicioServicio.GetLista();
        }

        public static implicit operator Servicio(Modelos.Servicio v)
        {
            throw new NotImplementedException();
        }
    }
}
