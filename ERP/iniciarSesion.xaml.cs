﻿using System;
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
    /// Lógica de interacción para iniciarSesion.xaml
    /// </summary>
    public partial class iniciarSesion : Window
    {
        public string user, password;
        conexionPersona newConexionPersona = new conexionPersona();
        public iniciarSesion()
        {
            InitializeComponent();
        }

        private void usuario_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            user = usuario_txt.Text;
        }

        private void password_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = password_txt.Text;
        }

        private void volver_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow menuPP = new MainWindow();
            menuPP.Show();
            this.Close();
        }

        private void entrar_btn_Click(object sender, RoutedEventArgs e)
        {
            bool verif = newConexionPersona.autentificar(user, password);

            if (verif)
            {
                this.Hide();
                MenuPP ventanaMenuPP = new MenuPP();
                ventanaMenuPP.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Al parecer no estás, crea una cuenta!!");
            }
        }
    }
}
