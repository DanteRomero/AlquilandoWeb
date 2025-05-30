using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Servicios;

namespace AL.Aplicacion.CasosDeUso;

public class CancelarReservaCasoDeUso
{
    private readonly ServicioReserva _servicioReserva;

    public CancelarReservaCasoDeUso(ServicioReserva servicioReserva)
    {
        _servicioReserva = servicioReserva;
    }

    public List<Reserva> ObtenerMisReservas()
    {
        return _servicioReserva.ObtenerReservasDelUsuario();
    }

    public string CancelarReserva(int idReserva)
    {
        return _servicioReserva.CancelarReservaConDemanda(idReserva);
    }
}