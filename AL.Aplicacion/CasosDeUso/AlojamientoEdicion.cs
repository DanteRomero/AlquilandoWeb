using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Validadores;
using AL.Aplicacion.Excepciones;
using AL.Aplicacion.Enumerativos;

namespace AL.Aplicacion.CasosDeUso;

public class AlojamientoEdicion(IAlojamientoRepositorio _repo, IAlojamientoValidador _validador) : AlojamientoCasoDeUso(_repo)
{
    public void Ejecutar(Alojamiento alojamiento, RolUsuario rol)
    {
        string mensajeError;
        if (rol != RolUsuario.Administrador)
            throw new AutorizacionException();

        if (!_validador.Validar(alojamiento, out mensajeError))
            throw new ValidacionException(mensajeError);

        Repositorio.Modificar(alojamiento);
    }
}