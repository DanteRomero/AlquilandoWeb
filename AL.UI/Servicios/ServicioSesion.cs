using System;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using AL.Aplicacion.Enumerativos;
using AL.Aplicacion.Interfaces;
namespace AL.UI.Servicios;

public class ServicioSesion: IServicioSesion
{
    private readonly IUsuarioRepositorio _repo;
    private readonly IHashService _hash;
    private readonly ProtectedSessionStorage _sessionStorage;

    public ServicioSesion(ProtectedSessionStorage sessionStorage, IUsuarioRepositorio repo, IHashService hash)
    {
        _repo = repo;
        _hash = hash;
        _sessionStorage = sessionStorage;
        
        // Intenta recuperar el rol al crear el servicio
        //var result = _localStorage.GetAsync<string>("rol").Result;
        //if (result.Success && Enum.TryParse(result.Value, out RolUsuario rol))
          //  Rol = rol;
        //else
            Rol = RolUsuario.Invitado;
    }

    public int Id { get; set; }

    public RolUsuario Rol { get; set; }

    public async Task<bool> Loggin(String email, String contraseña)
    {
        var result = IniciarSesion(email, contraseña);
        if (result)
            await GuardarUsuarioAsync();
        return result;
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
    public async Task GuardarUsuarioAsync()
    {
        await _sessionStorage.SetAsync("rol", Rol.ToString());
        await _sessionStorage.SetAsync("id", Id);
    }
    public async Task InicializarUsuarioAsync()
    {
        var result = await _sessionStorage.GetAsync<string>("rol");
        if (result.Success && Enum.TryParse(result.Value, out RolUsuario rol))
            Rol = rol;
        else
            Rol = RolUsuario.Invitado;
        var resultId = await _sessionStorage.GetAsync<int>("id");
        if (resultId.Success)
            Id = resultId.Value;
    }
    public async Task LogoutAsync()
    {
        Rol = RolUsuario.Invitado;
        Id = 0;
        await _sessionStorage.DeleteAsync("rol");
    }
    public void Logout()
    {
        LogoutAsync().GetAwaiter().GetResult();
    }
}