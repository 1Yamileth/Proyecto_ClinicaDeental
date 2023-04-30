using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        ClienteM clie = new ClienteM();

        protected async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(clie.IdentidadCliente) || string.IsNullOrWhiteSpace(clie.Nombre))
            {
                return;
            }

            ClienteM ClieExiste = new ClienteM();

            ClieExiste = await clienteServicio.GetPorCodigoAsync(clie.IdentidadCliente);

            if (ClieExiste != null)
            {
                if (!string.IsNullOrEmpty(clie.IdentidadCliente))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un Cliente con el mismo código", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await clienteServicio.NuevoAsync(clie);
            if (inserto)
            {
                await Swal.FireAsync("Atención", "Cliente Registrado con Exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo Registrar el Cliente", SweetAlertIcon.Error);
            }
        }

        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }
    }
}
