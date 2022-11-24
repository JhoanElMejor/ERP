using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        public string codigoFactura { get; set; }
        public string identificacion { get; set; }
        public int usuario { get; set; }
        //public string fechaFactura { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public double descuento { get; set; }
        public string codigoProducto { get; set; }
        public string cantidad { get; set; }
        public string nombreCliente { get; set; }
        public double precio { get; set; }
        public double acumulador = 0;

        DateTime thisDay = DateTime.Today;

        conexionPersona persona = new conexionPersona();

        conexionProducto producto = new conexionProducto();
        public Factura()
        {
            InitializeComponent();
        }

        private void numFactura_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            codigoFactura = numFactura_txt.Text;
        }

        private void identificacion_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            identificacion = identificacion_txt.Text;
        }

        private void codigoProducto_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            codigoProducto = codigoProducto_txt.Text;
        }

        private void cantidades_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            cantidad = cantidades_txt.Text;
        }

        private void fechaFactura_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void nombreCliente_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void descripcionProducto_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void valorProducto_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            //precio = Convert.ToDouble(valorProducto_txt.Text);
        }

        private void valorFactura_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            total = Convert.ToDouble(valorFactura_txt.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)// guardar
        {
            descuento = 0;
            double porc = 0;
            try
            {
                descuento = Convert.ToDouble(descuento_txt.Text) / 100;
                subtotal = Convert.ToDouble(subtotal_txt.Text);
                porc = Convert.ToDouble(subtotal_txt.Text) * descuento;
            }
            catch{ }

            

            if (descuento >= 0.1)
            {
                acumulador = (acumulador + (subtotal - porc)) * 1.19;
                string op = Convert.ToString(acumulador);
                valorFactura_txt.Text = op;
            }else
            {
                acumulador = (acumulador + (subtotal * 1.19));
                valorFactura_txt.Text = Convert.ToString(acumulador);
            }

            crearFactura f1 = new crearFactura(codigoFactura, identificacion, usuario, thisDay, total, subtotal, descuento * subtotal, codigoProducto, cantidad, precio);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // modificar
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //regresar
        {
            this.Hide();
            MenuPP menuPP = new MenuPP();
            menuPP.Show();
            this.Close();
        }

        private void imprimir_btn_Click(object sender, RoutedEventArgs e) // cargar
        {
            List<string> listProducto = producto.modificar(codigoProducto);
            precio = Convert.ToDouble(listProducto [1]);
            valorProducto_txt.Text = Convert.ToString(precio);

            List<string> datosP = new List<string>();
            datosP = persona.modificarCliente(identificacion);
            nombreCliente = datosP[0];
            nombreCliente_txt.Text = nombreCliente;

            
            nombreProducto_txt.Text = listProducto[0];

            
            fechaFactura_txt.Text = thisDay.ToString();

        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            double op = Convert.ToDouble(cantidad) * precio;
            subtotal_txt.Text = Convert.ToString(op);
        }

        private void subtotal_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            subtotal = Convert.ToDouble(subtotal_txt.Text);
        }

        private void imprimir_btn_Click_1(object sender, RoutedEventArgs e)
        {
            conexionFactura f2 = new conexionFactura();
            f2.imprimirFactura(codigoFactura);

        }
    }
}
