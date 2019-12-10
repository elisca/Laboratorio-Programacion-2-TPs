using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase que se conecta con la base de datos SQL en donde se guardan los datos de los paquetes
    /// </summary>
    public static class PaqueteDAO
    {
        static SqlCommand comando; //Instancia de comando para ejecutar consultas
        static SqlConnection conexion; //Instancia de conexion SQL
        
        //Variables varias para configurar los parametros de conexion a la base de datos
        static string nombreServidor=@".\SQLExpress";
        static string nombreBD="correo-sp-2017";
        static string nombreTabla = "dbo.Paquetes";
        static bool seguridadIntegrada=true;

        /// <summary>
        /// Inserta datos en la base
        /// </summary>
        /// <param name="p">Paquete</param>
        /// <returns>True-Escritura del registro exitosa, En caso de error lanza excepcion</returns>
        public static bool Insertar(Paquete p)
        {
            bool estadoInsercion = true;
            try //Intenta conectarse al servidor y ejecutar una consulta para insertar un registro con los datos del paquete, luego cierra la conexion
            {
                conexion.Open();
                comando.CommandText = string.Format(@"INSERT INTO {0} (direccionEntrega, trackingID, alumno) VALUES ('{1}', '{2}', 'Ezequiel Lisca')", nombreTabla, p.DireccionEntrega, p.TrackingID);
                comando.ExecuteNonQuery();
                conexion.Close();
                return estadoInsercion;
            }
            catch (Exception) //En caso de error, lanza una excepcion
            {
                throw new Exception("Error al intentar insertar datos en la tabla");
            }
            finally //Cierra la conexion
            {
                estadoInsercion = false;
                conexion.Close();
            }
        }

        /// <summary>
        /// Se configuran las instancias para preparar la conexion al servidor pero no la efectua
        /// </summary>
        static PaqueteDAO()
        {
            string strConexion = string.Format("Data source={0};Initial catalog={1};Integrated security={2};", nombreServidor, nombreBD, seguridadIntegrada.ToString());
            conexion = new SqlConnection(strConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }
    }
}
