using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Enumerativos;
namespace AL.Aplicacion.Validadores;

public class AlojamientoValidador(IAlojamientoRepositorio _alojamientoRepo):IAlojamientoValidador
{
    public bool Validar(Alojamiento a, out string mensajeError){
        mensajeError = "";
        if (_alojamientoRepo.ObtenerPorNombre(a.Nombre) != null)
        {
            mensajeError += "El nombre del alojamiento ingresado ya fue dado de alta anteriormente.\n";
        }
        if (string.IsNullOrWhiteSpace(a.Nombre))
        {
            mensajeError += "El nombre no puede estar vacio.\n";
        }
        if(String.IsNullOrWhiteSpace(a.Pais)){
            mensajeError+="Debe ingresar el país.\n"; 
        }
        if (string.IsNullOrWhiteSpace(a.Ciudad))
        {
            mensajeError += "La ciudad no puede estar vacia.\n";
        }
        if (string.IsNullOrWhiteSpace(a.Direccion)){
            mensajeError+="Debe ingresar la dirección.\n"; 
        }
        if (a.CapacidadMaxima <= 0){
            mensajeError+="Debe ingresar la capacidad máxima.\n"; 
        }
        if (a.CantidadDormitorios<=0){
            mensajeError+="Debe ingresar la cantidad de dormitorios.\n"; 
        }
        if(a.CantidadBaños<=0){
            mensajeError+="Debe ingresar la cantidad de baños.\n"; 
        }
        if (a.CantidadCamas <= 0)
        {
            mensajeError += "Debe ingresar la cantidad de camas.\n";
        }
        if (a.PrecioPorNoche<0){
            mensajeError+="Debe ingresar el precio por noche del alojamiento.\n"; 
        }
        if(String.IsNullOrWhiteSpace(a.Descripcion)){
            mensajeError+="Debe ingresar una descripción del alojamiento.\n"; 
        }
        if(String.IsNullOrWhiteSpace(a.Servicios)){
            mensajeError+="Debe ingresar los servicios del alojamiento.\n"; 
        }
        if (a.TipoDeReembolso == null || (a.TipoDeReembolso != TipoReembolso.NoReembolsable && 
            a.TipoDeReembolso != TipoReembolso.ReembolsoTotal && 
            a.TipoDeReembolso != TipoReembolso.ReembolsoParcial))
        {
            mensajeError += "Debe seleccionar un tipo de reembolso.\n"; 
        }
        return (mensajeError == "");
    }
}
