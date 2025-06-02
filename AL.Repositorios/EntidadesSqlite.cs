using System;
using Microsoft.EntityFrameworkCore;
namespace AL.Repositorios;

public class EntidadesSqlite
{
    public static void Inicializar(){

        using var context = new EntidadesContext();
        
        if (context.Database.EnsureCreated())
        {
            //Esto iría acá? O en model creating?
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }
}
