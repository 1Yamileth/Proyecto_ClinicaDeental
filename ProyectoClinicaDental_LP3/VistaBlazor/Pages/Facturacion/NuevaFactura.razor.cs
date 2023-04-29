using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Modelos;
using VistaBlazor.Interfaces;

namespace VistaBlazor.Pages.Facturacion
{
    public partial class NuevaFactura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private IServicioServicio servicioServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

        public Factura factura = new Factura();
        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Servicio servicio = new Servicio();

        private string codigoServicio { get; set; }

        protected override async Task OnInitializedAsync()
        {
            factura.FechaFactura = DateTime.Now;
        }

        private async void BuscarServicio()
        {
            servicio = await servicioServicio.GetPorCodigo(codigoServicio);
        }

        protected async Task AgregarServicio(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (servicio != null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.Descripcion = servicio.Descripcion;
                    detalle.CodigoServicio = servicio.CodigoServicio;
                    detalle.Precio = servicio.Precio;
                    detalle.Total = servicio.Precio;
                    listaDetalleFactura.Add(detalle);
                    servicio.Descripcion = string.Empty;
                    servicio.Precio = 0;
                    codigoServicio = "0";

                    factura.Subtotal = factura.Subtotal + detalle.Total;
                    factura.ISV = factura.Subtotal * 0.15M;
                    factura.Total = factura.Subtotal + factura.ISV - factura.Descuento;
                }
            }
        }

        protected async Task Guardar()
        {
            factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
            int idFactura = await facturaServicio.Nueva(factura);
            if (idFactura != 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detalleFacturaServicio.Nuevo(item);
                }
                await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }
        }

    }
}
