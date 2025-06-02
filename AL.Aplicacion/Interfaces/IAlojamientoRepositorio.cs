using System;
using AL.Aplicacion.Entidades;

namespace AL.Aplicacion.Interfaces;

public interface IAlojamientoRepositorio
{
    void Agregar(Alojamiento alojamiento);
    void Eliminar(Alojamiento alojamiento);
    void Modificar(Alojamiento alojamiento);
    Alojamiento? ObtenerPorNombre(string nombre);
    List<Alojamiento> ObtenerPorCiudadYDisponibilidad(String ciudad, DateTime fechaDesde, DateTime fechaHasta);
    List<Alojamiento> ObtenerTodos();
    public List<Alojamiento> ListarAlojamientosConSusReservas();    
    Task<Alojamiento?> ObtenerPorId(int id);
}
