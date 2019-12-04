using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;
        static string nombreBD="correo-sp-2017";
        static string nombreTabla="Paquetes";
        static bool seguridadIntegrada=true;

        public static bool Insertar(Paquete p)
        {
            try
            {
                comando.CommandText = @"INSERT INTO " + nombreTabla + " (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Ezequiel Lisca')";
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        static PaqueteDAO()
        {
            string strConexion = "Data source=" + nombreBD + ";Initial catalog=" + nombreTabla + ";Integrated security=" + seguridadIntegrada + ";";
            conexion = new SqlConnection(strConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
            conexion.Open();
        }
    }
}
