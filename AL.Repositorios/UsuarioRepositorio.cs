using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Enumerativos;
using Microsoft.EntityFrameworkCore;
namespace AL.Repositorios;

public class UsuarioRepositorio: IUsuarioRepositorio
{

    //Verificar que el usuario no exista
    public bool BuscarPorCorreoElectronico(String correo){
        using(var db=new EntidadesContext()){
            var usuario = db.Usuarios.Where(u=>u.CorreoElectronico.Equals(correo)).SingleOrDefault();
            if(usuario!=null){
                return true;
            }
            return false;
        }
    }

    //Agregar un usuario
    public int Agregar(Usuario u){
        using(var db = new EntidadesContext()){
            db.Usuarios.Add(u);
            db.SaveChanges();
            return u.Id;
        }
    }

    public int AsignarRol(int id, RolUsuario rol){
        using(var db = new EntidadesContext()){
            Usuario? usuario = db.Usuarios.Where(x => x.Id == id).SingleOrDefault();
            if(usuario != null){
                usuario.Rol = rol;
                db.Usuarios.Update(usuario);
                db.SaveChanges();
                return usuario.Id;
            }
            return 0;
        }
    }   
    
    //Dar de baja un usuario
    public void Eliminar(Usuario u)
    {
        using (var db = new EntidadesContext())
        {
            db.Usuarios.Remove(u);
            db.SaveChanges();
        }
    }

    public List<Usuario> ListarTodos(){
        using(var db = new EntidadesContext()){
            return db.Usuarios.ToList();
        }
    }

    public void ModificarTarjeta(Usuario u){
        using(var db = new EntidadesContext()){
            db.Usuarios.Update(u);
            db.SaveChanges();
        }
    }

    public Usuario? ObtenerPorId(int idUsuario){
        using (var db=new EntidadesContext()){
            Usuario? usuario = db.Usuarios.Where(x => x.Id == idUsuario).SingleOrDefault();
            return usuario;
        }
    }

    //Para iniciar Sesion
    public Usuario? IniciarSesion(String correo){
        using(var db= new EntidadesContext()){
            Usuario? usuario = db.Usuarios.Where(x=>x.CorreoElectronico == correo).SingleOrDefault();
            return usuario;
        }
    }


}
