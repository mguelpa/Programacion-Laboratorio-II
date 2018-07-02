using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public class PaqueteDAO
    {
        private static SqlConnection _conexion;
        private static SqlCommand _comandos;

        static string conectionSetting = @"Server=LAPTOP-MXN\SQLEXPRESS01;
                                           Database=correo-sp-2017;
                                           Integrated Security=SSPI;";

        public PaqueteDAO()
        {
            // 1. Genero la conexion, 2. Genero los Comandos
            PaqueteDAO._conexion = new SqlConnection(conectionSetting);
            PaqueteDAO._comandos = new SqlCommand();

            // 3. Seteo el tipo de comando, 4. 
            PaqueteDAO._comandos.CommandType = CommandType.Text;
            PaqueteDAO._comandos.Connection = PaqueteDAO._conexion;
        }

        /// <summary>
        /// inserta los datos de un paquete en una base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Insertar(Paquete p)
        {
            bool exito = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) ");
            sb.AppendFormat("VALUES( '{0}', '{1}', '{2}' )", p.DireccionEntrega, p.TrackingID, "Güelpa Maximiliano");

            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comandos.CommandText = sb.ToString();
                PaqueteDAO._comandos.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                exito = false;
               
            }
            finally
            {
                if (exito)
                    PaqueteDAO._conexion.Close();
            }
            return exito;
        }
    }
}
