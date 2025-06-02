using System;
using Microsoft.EntityFrameworkCore;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Repositorios;

public class AlojamientoRepositorio:IAlojamientoRepositorio
{
    //Caso de uso alojamiento ALTA
    public void Agregar(Alojamiento e){
        
        using(var db=new EntidadesContext()){  
            db.Add(e);
            db.SaveChanges();
        }
    }

    //Caso de uso alojamiento BAJA
    public void Eliminar(Alojamiento e){
        using(var db=new EntidadesContext()){  
            var expediente = db.Alojamientos.Where(t => t.Id == e.Id).SingleOrDefault();
            if(expediente != null){
                 db.Remove(expediente);
                 db.SaveChanges();
        }
        }
    }
    //Consulta por Id, para que el administrador pueda ver los detalles de un alojamiento
    public async Task<Alojamiento?> ObtenerPorId(int id)
    {
        using (var db = new EntidadesContext())
        {
            return await db.Alojamientos.FindAsync(id);
        }
    }
    public Alojamiento? ObtenerPorNombre(string nombre)
    {
        using (var db = new EntidadesContext())
        {
            var alojamiento = db.Alojamientos.Where(a => a.Nombre != null && a.Nombre.Equals(nombre)).SingleOrDefault();
            return alojamiento;
        }
    }
    
    //Creo que este método va a servir para "Buscar Alojamiento" en la UI
    public List<Alojamiento> ObtenerPorCiudadYDisponibilidad(String ciudad, DateTime fechaDesde,DateTime fechaHasta)
    {
        using (var db = new EntidadesContext())
        {
            return db.Alojamientos
            .Include(a => a.Reservas)
            .Where(a => a.Ciudad != null && a.Ciudad.ToLower() == ciudad.ToLower())
            .Where(a => a.Reservas == null || !a.Reservas.Any(r =>
                r.FechaInicioEstadia.Date <= fechaHasta.Date && r.FechaFinEstadia.Date >= fechaDesde.Date
            ))
            .ToList();
        }
    }
    public List<Alojamiento> ListarAlojamientosConSusReservas()
    {
        using(var db = new EntidadesContext()){
            return db.Alojamientos.Include(a => a.Reservas).ToList();
        }
    } 

    
    //Caso de uso consulta TODOS
    public List<Alojamiento> ObtenerTodos(){
        using (var db=new EntidadesContext()){
            List<Alojamiento> resultado = db.Alojamientos.ToList();
            return resultado;  
        }
    }


    //Caso de uso alojamiento MODIFICACION
    public void Modificar(Alojamiento e){
        using(var db=new EntidadesContext()){  
            db.Alojamientos.Update(e);
            db.SaveChanges();
        }
    }
}
