using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using ERP.Datos;
using MySql.Data.MySqlClient;

namespace ERP
{
    public class conexionPersona : ConexionBD
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string id { get; set; }
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

        public void crearCliente(string _nombre, string _apellido, string _id, string _direccion, string _telefono)
        {
            id = _id;
            bool verif = false;
            MySqlCommand cmd;
            string consulta = "";
            try
            {
                getEnlace().Open();
                consulta = "select identificacion from cliente";
                cmd = new MySqlCommand(consulta, getEnlace());
                MySqlDataReader info = cmd.ExecuteReader();
                while (info.Read())
                {
                    if (info.GetString(0) == _id)
                    {
                        verif = true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
            getEnlace().Close();

            if (verif)
            {
                if(_nombre != null && _apellido != null && _id != null && _direccion != null && _telefono != null)
                {
                    try
                    {
                        getEnlace().Open();
                        consulta = "update cliente set nombre = @n, apellido = @a, identificacion = @i, direccion =  @d, telefono = @t where identificacion = @id  ";
                        cmd = new MySqlCommand(consulta, getEnlace());
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@n", _nombre);
                        cmd.Parameters.AddWithValue("@a", _apellido);
                        cmd.Parameters.AddWithValue("@i", _id);
                        cmd.Parameters.AddWithValue("@id", _id);
                        cmd.Parameters.AddWithValue("@d", _direccion);
                        cmd.Parameters.AddWithValue("@t", _telefono);
                        cmd.ExecuteReader();
                        MessageBox.Show("Cliente actualizado con exito!");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(Convert.ToString(e));
                    }
                }else
                {
                    MessageBox.Show("Llene todos los campos!");
                }
                

                getEnlace().Close();
            }
            else
            {
                try
                {
                    getEnlace().Open();
                    consulta = "insert into cliente (nombre, apellido, identificacion, direccion, telefono) values (@nombre, @apellido, @identificacion, @direccion, @telefono)";
                    cmd = new MySqlCommand(consulta, getEnlace());
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nombre", _nombre);
                    cmd.Parameters.AddWithValue("@apellido", _apellido);
                    cmd.Parameters.AddWithValue("@identificacion", _id);
                    cmd.Parameters.AddWithValue("@direccion", _direccion);
                    cmd.Parameters.AddWithValue("@telefono", _telefono);
                    cmd.ExecuteReader();

                    MessageBox.Show("Cliente ingresado con exito!");

                } catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                }


                getEnlace().Close();
            }
        }

        public List<String> modificarCliente(string _id)
        {
            List<String> datosCliente = new List<String>();
            MySqlDataReader info;
            id = _id;
            try
            {
                getEnlace().Open();
                string consulta = "select nombre, apellido, direccion, telefono, identificacion from cliente where identificacion = @id";
                MySqlCommand cmd = new MySqlCommand(consulta, getEnlace());
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                info = cmd.ExecuteReader();
                info.Read();
                datosCliente.Add(info.GetString(0));
                datosCliente.Add(info.GetString(1));
                datosCliente.Add(info.GetString(2));
                datosCliente.Add(info.GetString(3));
                datosCliente.Add(info.GetString(4));
                MessageBox.Show("Entra");
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
          
            getEnlace().Close();

            return datosCliente;
        }

    }
}
