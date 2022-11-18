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
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        public string id, nombre, apellido, direccion, telefono;
        conexionPersona conexionPersona = new conexionPersona();
        public Clientes()
        {
            InitializeComponent();
        }

        private void nombre_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombre = nombre_txt.Text;
        }

        private void apellido_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            apellido = apellido_txt.Text;
        }

        private void id_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = id_txt.Text;
        }

        private void direccion_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            direccion = direccion_txt.Text;
        }

        private void telefono_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            telefono = telefono_txt.Text;
        }


        private void guardar_btn_Click(object sender, RoutedEventArgs e)
        {
            
            conexionPersona.crearCliente(nombre, apellido, id, direccion, telefono);

            nombre_txt.Clear();
            apellido_txt.Clear();
            id_txt.Clear();
            direccion_txt.Clear();
            telefono_txt.Clear();
        }

        private void modificar_btn_Click(object sender, RoutedEventArgs e)
        {
            if (id == null)//error a hora de modificar 2 clientes a la vez
            {
                MessageBox.Show("Pon la identificacion en el campo **identificacion**");
            }
            else
            {
                List<string> datosClientes = conexionPersona.modificarCliente(id);
                nombre_txt.Text = datosClientes[0];
                apellido_txt.Text = datosClientes[1];
                direccion_txt.Text = datosClientes[2];
                telefono_txt.Text = datosClientes[3];
                id_txt.Text = datosClientes[4];
            }
            
        }
    }
}
