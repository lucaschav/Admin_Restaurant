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
    public partial class Categ : Form
    {
        public Categ()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("Server=" + Ajustes.datos_conect[0] + ";" + "Database=" + Ajustes.datos_conect[1] + ";" + "Uid=" + Ajustes.datos_conect[2] + ";" + "Pwd=" + Ajustes.datos_conect[3] + "");
        private void Categ_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM categoria", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataCategoria.DataSource = tabla;
            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "INSERT INTO categoria (NOMBRE) VALUES ('" + txtCategoria.Text + "');";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("CATEGORIA CREADA CON EXITO");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "UPDATE categoria SET NOMBRE='" + txtCategoria.Text + "'WHERE ID='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("CATEGORIA ACTUALIZADA CON EXITO");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "DELETE FROM categoria WHERE ID='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("CATEGORIA ELIMINADA CON EXITO");
        }
    }
}
