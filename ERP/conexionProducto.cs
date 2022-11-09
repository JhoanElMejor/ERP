using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ERP.Datos;
using MySql.Data.MySqlClient;

namespace ERP
{
    public class conexionProducto: ConexionBD
    {
        public conexionProducto()
        {
        }
        public List<string> modificar(string _id)
        {
            List<string> datosTextBox = new List<string>();

            try
            {
                getEnlace().Open();
                string consulta = "select nombre, precio_venta, sede from producto where id_producto = @id";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.ExecuteNonQuery();
                MySqlDataReader info = cmd.ExecuteReader();
                info.Read();
                datosTextBox.Add(info.GetString(0));
                datosTextBox.Add(info.GetString(1));
                datosTextBox.Add(info.GetString(2));

                MessageBox.Show(datosTextBox[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }

            getEnlace().Close();
            return datosTextBox;
        }
    }
}
