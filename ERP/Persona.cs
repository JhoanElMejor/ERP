using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ERP.Datos;
using MySql.Data.MySqlClient;

namespace ERP
{
    
    public class Persona: ConexionBD
    {
        public string codigoUsuario;
        public string nombreUsuario;
        public string password;


        public Persona(string _codigoUsuario, string _nombreUsuario, string _password)
        {
            this.codigoUsuario = _codigoUsuario;
            this.nombreUsuario = _nombreUsuario;
            this.password = _password;


            try
            {
                getEnlace().Open();
                string consulta = "insert into usuario (id, usuario, contrasena) values (@id, @usuario, @contrasena)";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id",codigoUsuario);
                cmd.Parameters.AddWithValue("@usuario",nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena",password);
                MySqlDataReader ejecucion = cmd.ExecuteReader();    

                MessageBox.Show("Usuario creado con exito!!!");

            } catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }

            getEnlace().Close();
        }
    }
}
