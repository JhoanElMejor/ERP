using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ERP.Datos
{
    public class ConexionBD
    {
        private MySqlConnection enlace = new MySqlConnection();
        public ConexionBD ()
        {
            try
            {
                enlace.ConnectionString = "server = localhost; database = erp; user = root"; ;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public MySqlConnection getEnlace()
        {
            return enlace;
        }

    }
}
