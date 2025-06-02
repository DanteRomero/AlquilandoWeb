using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Aplicacion.Validadores;

public class UsuarioValidador(IUsuarioRepositorio _usuarioRepo): IUsuarioValidador
{
    public bool Validar(Usuario u, out String mensajeError)
    {
        mensajeError = "";
        if(_usuarioRepo.BuscarPorCorreoElectronico(u.CorreoElectronico)){ 
            mensajeError+="El correo electronico se encuentra en uso.\n";
        }
        if (u.FechaDeNacimiento.Year > DateTime.Now.Year - 18)
        {
            mensajeError +="El usuario debe ser mayor de edad.\n";
        }
        if (string.IsNullOrWhiteSpace(u.Nombre))
        {
            mensajeError += "La casilla de Nombre no puede estar vacía.\n";
        }
        if (string.IsNullOrWhiteSpace(u.Apellido)){
            mensajeError += "La casilla de Apellido no puede estar vacía.\n";
        }
        if (string.IsNullOrWhiteSpace(u.CorreoElectronico)){
            mensajeError += "El correo electrónico no puede estar vacío.\n";
        }
        if (!u.CorreoElectronico.Contains("@"))
        {
            mensajeError += "El correo electrónico debe contener un '@'.\n";
        }
        return (mensajeError == "");
    }   
}
