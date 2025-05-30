using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Enumerativos;
using AL.Aplicacion.Interfaces;

namespace AL.Aplicacion.Servicios;

public class ServicioSesion(IUsuarioRepositorio _repo, IHashService _hash) : IServicioSesion
{

    public int Id { get; set; }
    public RolUsuario Rol { get; set; }

    public bool EstaLogueado => Id != 0 && Rol != RolUsuario.Invitado;

    public async Task<bool> Loggin(String email, String contraseña)
    {
        return await Task.Run(() => IniciarSesion(email, contraseña));
    }

    private bool IniciarSesion(string email, string contraseña)
    {
        var usuario = _repo.IniciarSesion(email);
        if (usuario == null)
        {
            return false;
        }

        if (_hash.VerifyHash(contraseña, usuario.HashContraseña, usuario.SalContraseña))
        {
            Id = usuario.Id;
            Rol = usuario.Rol;
            return true;
        }

        return false;
    }

    public void Logout()
    {
        this.Id = 0;
        this.Rol = RolUsuario.Invitado;
    }
    
}
