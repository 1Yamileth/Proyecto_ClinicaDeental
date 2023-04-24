using Modelos;

namespace VistaBlazor.Interfaces
{
    public interface ILoginServicio
    {
        Task<bool> ValidarUsuarioAsync(Login login);
    }
}
