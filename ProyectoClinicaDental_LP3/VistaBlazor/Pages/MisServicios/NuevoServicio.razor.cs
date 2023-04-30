using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisServicios
{
    public partial class NuevoServicio
    {
        [Inject] private IServicioServicio servicioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        ServicioM prod = new ServicioM();



        protected async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(prod.CodigoServicio) || string.IsNullOrWhiteSpace(prod.Descripcion))
            {
                return;
            }

            ServicioM prodExistente = new ServicioM();

            prodExistente = await servicioServicio.GetPorCodigo(prod.CodigoServicio);

            if (prodExistente != null)
            {
                if (!string.IsNullOrEmpty(prodExistente.CodigoServicio))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un servicio con el mismo código", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await servicioServicio.Nuevo(prod);
            if (inserto)
            {
                await Swal.FireAsync("Atención", "Servicio guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el servicio", SweetAlertIcon.Error);
            }
        }

        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Servicio");
        }
    }
}
