using ERP.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Security.Policy;

namespace ERP
{
    public class conexionFactura: ConexionBD
    {
        public string codigoFactura { get; set; }
        public conexionFactura()
        {

        }
        
        public void imprimirFactura(string _codigoFactura)
        {
            codigoFactura = _codigoFactura;
            List<string> lista = new List<string>();
            lista = imprimirDetalleFactura();

            try
            {
                getEnlace().Open();
                string consulta = "select * from factura where numero = @numero";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@numero", codigoFactura);
                MySqlDataReader info = cmd.ExecuteReader();
                string variable = "";
                foreach (string item in lista)
                {
                    variable = variable + "\n" + item ;
                }

                info.Read();
                MessageBox.Show($"Codigo factura: {info.GetString(1)}\nID cliente: {info.GetString(2)}\nID Usuario: {info.GetString(3)}\nFecha factura: {info.GetString(4)}\nsubtotal: {info.GetString(6)}\ntotal + iva %19: {info.GetString(5)}\nDescuento: {info.GetString(8)}\n---------detalle factura---------\nID Producto - Cantidad - Precio\n {variable} ", "Factura");

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            getEnlace().Close();
        }

        public List <string> imprimirDetalleFactura()
        {
            List<string> listaProducto = new List<string>(); 

            try
            {
                getEnlace().Open();
                string consulta = "select * from descripcion_fact where fk_id_factura = @numero";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@numero", codigoFactura);
                MySqlDataReader info = cmd.ExecuteReader();
                while (info.Read())
                {
                    listaProducto.Add($"{info.GetString(1)} - {info.GetString(2)} - {info.GetString(4)}");
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            getEnlace().Close();

            return listaProducto;
        }
    }
}
