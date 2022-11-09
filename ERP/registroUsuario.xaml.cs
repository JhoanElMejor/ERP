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
using MySql.Data.MySqlClient;

namespace ERP
{
    /// <summary>
    /// Lógica de interacción para registroUsuario.xaml
    /// </summary>
    public partial class registroUsuario : Window
    {
        public string id;
        public string nombreUsuario;
        public string password;
        public registroUsuario()
        {
            InitializeComponent();
        }

        private void CodigoUsuario_lbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = CodigoUsuario_txt.Text;
        }

        private void nombreUsuario_lbl_TextChanged(object sender, TextChangedEventArgs e)
        {
            nombreUsuario = nombreUsuario_txt.Text;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = passwordUsuario_txt.Text;
        }

        private void inscribirse_btn_Click(object sender, RoutedEventArgs e)
        {
            Persona newPersona = new Persona(id, nombreUsuario, password);

            CodigoUsuario_txt.Clear();
            nombreUsuario_txt.Clear();
            passwordUsuario_txt.Clear();
        }
    }
}
