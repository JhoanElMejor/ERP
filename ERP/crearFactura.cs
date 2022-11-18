using ERP.Datos;
using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace ERP
{
    public class crearFactura: ConexionBD
    {
        public string codigoFactura { get; set; }
        public string identificacion  { get; set; }
        public int usuario { get; set;}
        public DateTime fechaFactura { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public double descuento { get; set; }
        public string codigoProducto { get; set; }
        public string cantidad { get; set; }
        public double precio { get; set; }
        //------------------------------------------------


        public crearFactura(string _codigoFactura, string _identificacion, int _usuario, DateTime _fechaFactura, double _total, double _subtotal, double _descuento, string _codigoProducto, string _cantidad, double _precio)
        {
            codigoFactura = _codigoFactura;
            identificacion = _identificacion;
            usuario = _usuario;
            fechaFactura = _fechaFactura;
            total = _total;
            subtotal = _subtotal;
            descuento = _descuento;
            codigoProducto = _codigoProducto;
            cantidad = _cantidad;
            precio = _precio;

            bool comprobar = verif(codigoFactura);

            if (comprobar != true)
            {
                try
                {
                    getEnlace().Open();
                    string consulta = "insert into factura  (cliente, usuario, fecha_facturacion, total, subtotal, descuento) values (@cliente, @usuario, @fecha, @total, @subtotal, @descuento)";
                    MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@cliente", Convert.ToInt64(identificacion));
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@fecha", fechaFactura);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Factura generada con exito!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                }
                getEnlace().Close();
            }

            detalleFactura();
            
        }

        public void detalleFactura()
        {
            try
            {
                getEnlace().Open();
                string consulta = "insert into descripcion_fact (fk_id_producto, cantidad, fk_id_factura, precio) values (@fk_id_producto, @cantidad, @fk_id_factura, @precio)";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                //cmd.Parameters.AddWithValue("@id_desc", identificacion);
                cmd.Parameters.AddWithValue("@fk_id_producto", codigoProducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@fk_id_factura", codigoFactura);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Entra a detalle de factura");

            }catch(Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            getEnlace().Close();
        }

        public bool verif(string _codigoFactura)
        {

            bool res = false;

            try
            {
                getEnlace().Open();
                string consulta = "select numero from factura";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                MySqlDataReader info = cmd.ExecuteReader();

                while(info.Read())
                {
                   if(info.GetString(0) == _codigoFactura)
                    {
                        res = true;
                        break;
                    } 
                }
            }catch( Exception e)
            {
                MessageBox.Show(Convert.ToString(e));

            }
            getEnlace().Close();

            return res;
        }
    }
}
