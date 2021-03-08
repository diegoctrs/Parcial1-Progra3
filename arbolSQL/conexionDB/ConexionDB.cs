using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolSQL.conexionDB
{
    class ConexionDB
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string db = "dbanimales";
            string usuario = "root";
            string password = "dcontrerasg3";

            string cadenaConexion = "Database=" + db + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection conexionDB = new MySqlConnection(cadenaConexion);
                return conexionDB;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

    }
}
