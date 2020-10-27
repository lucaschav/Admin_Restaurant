using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("Server=" + Ajustes.datos_conect[0] + ";" + "Database=" + Ajustes.datos_conect[1] + ";" + "Uid=" + Ajustes.datos_conect[2] + ";" + "Pwd=" + Ajustes.datos_conect[3] + "");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Reserva_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("SELECT * FROM reservaciones", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = com;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataReservas.DataSource = tabla;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "INSERT INTO reservaciones (NOMBRE, APELLIDO, HORA, FECHA) VALUES ('" + txtNom.Text + "','" + txtAp.Text + "','" + txtHs.Text + "','" + txtFecha.Text + "');";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("RESERVA GENERADA CON EXITO");
            conexion.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "DELETE FROM reservaciones WHERE ID ='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("RESERVA ELIMINADA CON EXITO. ID: " + txtId.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string query = "UPDATE reservaciones SET NOMBRE='" + txtNom.Text +
                                                    "',APELLIDO='" + txtAp.Text +
                                                    "',HORA='" + txtHs.Text +
                                                    "',FECHA='" + txtFecha.Text +
                                                    "'WHERE ID='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(query,conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("DATOS ACTUALIZADO CORRECTAMENTE");
        }
    }
}
