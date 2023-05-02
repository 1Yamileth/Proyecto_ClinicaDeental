using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MiClientes
{
    public partial class EditarCliente
    {
        [Inject] private IClienteServicio ClienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        ClienteM clie = new ClienteM();

        [Parameter] public string IdentidadCliente { get; set; }

        string imgUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(IdentidadCliente))
            {
                clie = await ClienteServicio.GetPorCodigoAsync(IdentidadCliente);
            }
        }
        protected async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(clie.IdentidadCliente) || string.IsNullOrWhiteSpace(clie.IdentidadCliente))
            {
                return;
            }

            bool edito = await ClienteServicio.ActualizarAsync(clie);
            if (edito)
            {
                await Swal.FireAsync("Atención", "Cliente guardado", SweetAlertIcon.Success);
                navigationManager.NavigateTo("/Cliente");


            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el Cliente", SweetAlertIcon.Error);

            }
        }

        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Cliente");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el Cliente?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await ClienteServicio.EliminarAsync(clie.IdentidadCliente);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Cliente eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Cliente");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el Cliente", SweetAlertIcon.Error);
                }
            }
        }
    }
}