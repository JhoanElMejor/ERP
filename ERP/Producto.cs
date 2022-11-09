using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ERP.Datos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace ERP
{
    public class crearProducto: ConexionBD
    {
        public string Id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string sede { get; set; }
        public crearProducto(string _id, string _nombre,  double _precio, string _sucursal)
        {
            Id = _id;
            nombre = _nombre;
            precio = _precio;
            sede = _sucursal;

            try
            {
                getEnlace().Open();
                string consulta = "insert into producto (id_producto, nombre, precio_venta, sede) values (@id_producto, @nombre, @precio_venta, @sede)";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_producto", Id);
                cmd.Parameters.AddWithValue("@nombre",nombre);
                cmd.Parameters.AddWithValue("@precio_venta", precio);
                cmd.Parameters.AddWithValue("@sede", sede);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto ingresado con exito!");
            }
            catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            getEnlace().Close();
        } 
    }
}
