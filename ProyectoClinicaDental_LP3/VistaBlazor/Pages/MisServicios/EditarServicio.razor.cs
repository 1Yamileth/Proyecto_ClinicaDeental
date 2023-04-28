﻿using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.MisServicios
{
    public partial class EditarServicios
    {
        [Inject] private IServicioServicio servicioServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        Servicio prod = new Servicio();

        [Parameter] public string Codigo { get; set; }

        string imgUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                prod = await servicioServicio.GetPorCodigo(Codigo);
            }
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(prod.CodigoServicio) || string.IsNullOrWhiteSpace(prod.descripcion))
            {
                return;
            }

            bool edito = await servicioServicio.Actualizar(prod);
            if (edito)
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
            navigationManager.NavigateTo("/Servicios");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el servicio?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await servicioServicio.Eliminar(prod.codigoServicio);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Producto eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Servicios");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el servicio", SweetAlertIcon.Error);
                }
            }
        }
    }
}
