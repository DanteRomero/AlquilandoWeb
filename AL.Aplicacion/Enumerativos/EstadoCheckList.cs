namespace AL.Aplicacion.Enumerativos;

public enum EstadoCheckList
{
    SinProblemas,      // Todo en orden
    DetallesMenores,   // Algún daño mínimo --> se soluciona en el día y en todo caso se manda mail al proximo inquilino dando aviso.
    RequiereReparacion // Algo serio --> se recomienda archivar publicacion y reparar
}