using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Excepciones;
using AL.Aplicacion.Enumerativos;

namespace AL.Aplicacion.CasosDeUso;

public class ReservaAlta
{
    private readonly IReservasRepositorio _reservasRepositorio;
    private readonly ITarjetaRepositorio _tarjetaRepositorio;
    private readonly IServicioSesion _sesion;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IAlojamientoRepositorio _alojamientoRepositorio;
    private readonly IServicioPago _servicioPago;


    public ReservaAlta(IReservasRepositorio reservasRepo, ITarjetaRepositorio tarjetaRepo, IServicioSesion sesion, IUsuarioRepositorio usuarioRepo, IServicioPago servicioPago, IAlojamientoRepositorio alojamientoRepo)
    {
        _reservasRepositorio = reservasRepo;
        _tarjetaRepositorio = tarjetaRepo;
        _sesion = sesion;
        _usuarioRepositorio = usuarioRepo;
        _servicioPago = servicioPago;
        _alojamientoRepositorio = alojamientoRepo;
    }
    public String Ejecutar(Reserva reserva)
    {
        var usuario = _usuarioRepositorio.ObtenerPorId(_sesion.Id);

        if (usuario == null)
            throw new Exception("Inicie Sesion");

        var tarjeta = _tarjetaRepositorio.ObtenerPorId(usuario.TarjetaId);
        if (tarjeta == null)
            throw new ValidacionException("No se encontró la tarjeta del usuario");

        bool pagoExitoso = _servicioPago.ValidarPago(tarjeta);
        if (!pagoExitoso)
            return "Reserva rechazada por error en el pago";

        bool requiereInfoAdicional = reserva.ListaInformacionAdicional != null && reserva.ListaInformacionAdicional.Count > 0;

        if (requiereInfoAdicional)
        {
            reserva.EstadoReserva = EstadoReserva.Pendiente;

            _reservasRepositorio.Agregar(reserva);
            return "La solicitud de reserva fue enviada";
        }
        else
        {
            reserva.EstadoReserva = EstadoReserva.Confirmada;
            _reservasRepositorio.Agregar(reserva);
            return "Reserva exitosa";
        }

    }
}

