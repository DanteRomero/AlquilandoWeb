using System;
using Microsoft.EntityFrameworkCore;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Repositorios;

public class ReservasRepositorio: IReservasRepositorio
{
//Caso de uso reserva ALTA
    public void Agregar(Reserva r){
        
        using(var db=new EntidadesContext()){  
            db.Add(r);
            db.SaveChanges();
        }
    }

    //Caso de uso reserva BAJA
    public void Eliminar(Reserva r){
        using(var db=new EntidadesContext()){  
            var expediente = db.Alojamientos.Where(t => t.Id == r.Id).SingleOrDefault();
            if(expediente != null){
                 db.Remove(expediente);
                 db.SaveChanges();
        }
        }
    }

    //Caso de uso Consulta por Id
    public Reserva? ObtenerPorId(int id){
        using(var db=new EntidadesContext()){  
            var expediente = db.Reservas.Where(t => t.Id == id).SingleOrDefault();
            return expediente;
        }
    } 
    
    //Caso de uso consulta TODOS
    public List<Reserva> ObtenerTodos(){
        using (var db=new EntidadesContext()){
            List<Reserva> resultado = db.Reservas.ToList();
            return resultado;  
        }
    }
    public List<Reserva> ObtenerReservasPorAlojamientoId(int alojamientoId)
    {
        using (var db = new EntidadesContext())
        {
            return db.Reservas.Where(r => r.IdAlojamiento == alojamientoId).ToList();
        }
    }
    public List<Reserva> ObtenerReservasPorUsuarioId(int usuarioId)
    {
        using (var db = new EntidadesContext())
        {
            return db.Reservas.Where(r => r.IdUsuario == usuarioId).ToList();
        }
    }

    //Caso de uso reserva MODIFICACION (puede que no se use)
    public void Modificar(Reserva r)
    {
        using (var db = new EntidadesContext())
        {
            db.Reservas.Update(r);
            db.SaveChanges();
        }
    }
}
