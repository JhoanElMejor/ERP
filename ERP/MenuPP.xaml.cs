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
            Producto ventanaProduto = new Producto();
            ventanaProduto.Show();
        }

        private void cliente_btn_Click(object sender, RoutedEventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
            MenuPP menuPP = new MenuPP();
            menuPP.Hide();
        }

        private void factura_btn_Click(object sender, RoutedEventArgs e)
        {
            Factura f = new Factura();
            f.Show();
            this.Hide();
        }
    }
}
