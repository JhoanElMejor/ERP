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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, object e)//registrar
        {
            registroUsuario regU = new registroUsuario();
            regU.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//iniciar sesion
        {
            this.Hide();
            iniciarSesion iniciarSesion = new iniciarSesion();
            iniciarSesion.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            registroUsuario registroUsuario = new registroUsuario();
            registroUsuario.Show();
        }

        private void salir_btn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes) 
            {
                this.Close();
            }

        }
    }
}
