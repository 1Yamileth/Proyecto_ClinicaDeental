using Modelos;

namespace Datos.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<bool> ValidarUsuarioAsync(Login login);
    }
}
