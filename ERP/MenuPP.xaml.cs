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
    /// Lógica de interacción para MenuPP.xaml
    /// </summary>
    public partial class MenuPP : Window
    {
        public MenuPP()
        {
            InitializeComponent();
        }

        private void producto_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Producto ventanaProduto = new Producto();
            ventanaProduto.Show();
            this.Close();
        }

        private void cliente_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Clientes clientes = new Clientes();
            clientes.Show();
            this.Close();
        }

        private void factura_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Factura f = new Factura();
            f.Show();
            this.Close();
        }

        private void salir_btn_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void cerrarSesion_btn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro?", "cerrar sesion", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
