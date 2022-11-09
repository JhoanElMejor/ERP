using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public string id  {get; set;}
        public string nombre { get; set; }
        public string precio { get; set; }
        public string sucursal { get; set; }
        
        conexionProducto newConexionProducto = new conexionProducto();

        public Producto()
        {
            InitializeComponent();
        }


        private void codigo_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = codigo_txt.Text;
        }

        private void precio_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            precio = precio_txt.Text;
        }

        private void nombre_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombre = nombre_txt.Text;
        }

        private void sucursal_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            sucursal = sucursal_txt.Text;
        }

        private void guardar_btn_Click(object sender, RoutedEventArgs e)
        {
            crearProducto p1 = new crearProducto(id, nombre, Convert.ToDouble(precio), sucursal);
        }

        private void modificar_btn_Click(object sender, RoutedEventArgs e)
        {
            List<string> datosObtenidos = new List<string>();

            try
            {
                if (id != null)
                {
                    datosObtenidos = newConexionProducto.modificar(id);
                    //id = datosObtenidos[0];
                    nombre = datosObtenidos[0];
                    precio = datosObtenidos[1];
                    sucursal = datosObtenidos[2];

                    //codigo_txt.Text = id;
                    precio_txt.Text = Convert.ToString(precio);
                    nombre_txt.Text = nombre;
                    sucursal_txt.Text = sucursal;

                }
                else
                {
                    MessageBox.Show("Pon el codigo en el recuadro de codigo");
                }
            }catch
            {

            }
            


            
        }
    }
}
