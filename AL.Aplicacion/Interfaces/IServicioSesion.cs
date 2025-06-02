using System;
using AL.Aplicacion.Enumerativos;

namespace AL.Aplicacion.Interfaces;

public interface IServicioSesion
{
    public int Id { get; set; }
    public RolUsuario Rol { get; set; }
    public Task<bool> Loggin(string email, string contraseña);
    public void Logout();
    public Task InicializarUsuarioAsync();

}
