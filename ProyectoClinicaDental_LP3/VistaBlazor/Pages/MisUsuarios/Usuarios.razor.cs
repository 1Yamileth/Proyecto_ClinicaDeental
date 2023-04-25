using VistaBlazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace VistaBlazor.MisUsuarios
{
    public partial class Usuarios
    {
        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        private IEnumerable<Usuario> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await usuarioServicio.GetListaAsync();
        }

    }
}
