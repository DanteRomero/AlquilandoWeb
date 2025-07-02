using System;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.Interfaces;

public interface IReservasRepositorio
{

    void Agregar(Reserva reserva);
    void Eliminar(Reserva reserva);
    void Modificar(Reserva reserva);
    Reserva? ObtenerPorId(int id);
    List <Reserva> ObtenerTodos();
    //Los siguientes métodos los agrego por si los necesitamos en el futuro
    List<Reserva> ObtenerReservasPorAlojamientoId(int alojamientoId);
    List<Reserva> ObtenerReservasPorUsuarioId(int usuarioId);
}
