using System;
using AL.Aplicacion.Enumerativos;

namespace AL.Aplicacion.Entidades;

//No se si es mejor que se llame Publicacion en vez de Alojamiento?
public class Alojamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; } ="";
    public String? Ciudad { get; set; }
    public String? Direccion { get; set; }
    public int CapacidadMaxima { get; set; }
    public int CantidadDormitorios { get; set; }
    public int CantidadCamas { get; set; }
    public int CantidadBaños { get; set; }
    public String? Descripcion { get; set; }
    public String? Servicios { get; set; }
    public String? Pais { get; set; }
    public Boolean Estacionamiento { get; set; } = false;
    public double PrecioPorNoche { get; set; }
    public TipoReembolso? TipoDeReembolso { get; set; } 
    public List<String> Imagenes { get; set; } = new List<string>();
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();

}
