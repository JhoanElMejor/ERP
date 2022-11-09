using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ERP.Datos;
using MySql.Data.MySqlClient;

namespace ERP
{
    public class conexionPersona : ConexionBD
    {
        public string usuario, password;
        public conexionPersona()
        {
            
        }
        public void autentificar(string _usuario, string _password)
        {
            usuario = _usuario;
            password = _password;
            bool verif = false;
            try
            {
                getEnlace().Open();
                string consulta = "select * from usuario";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                MySqlDataReader autentificador = cmd.ExecuteReader();
                while (autentificador.Read())
                {
                    if (usuario == autentificador.GetString(1) && password == autentificador.GetString(2))
                    {
                        verif = true;
                    }
                }

                if (verif)
                {
                    MenuPP ventanaMenuPP = new MenuPP();
                    ventanaMenuPP.Show();
                }
                else
                {
                    MessageBox.Show("No estás, crea una cuenta!!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            getEnlace().Close();
        }

    }
}
