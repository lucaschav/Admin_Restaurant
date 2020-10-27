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
    public partial class Platillos : Form
    {
        public Platillos()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("Server=" + Ajustes.datos_conect[0] + ";" + "Database=" + Ajustes.datos_conect[1] + ";" + "Uid=" + Ajustes.datos_conect[2] + ";" + "Pwd=" + Ajustes.datos_conect[3] + "");
        private void Platillos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand com = new MySqlCommand("SELECT * FROM platillos", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = com;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataPlatillos.DataSource = tabla;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int disp;
            
            if(chkDisp.Checked)
            {
                disp = 1;
            }
            else
            {
                disp = 0;
            }

            conexion.Open();

            string query = "INSERT INTO platillos (NOMBRE,PRECIO,DISPONIBLE,CATEGORIAID) VALUES ('" + txtNom.Text + "','" + txtprecio.Text + "','" + disp + "','" + txtCateg.Text + "');";
            MySqlCommand comando = new MySqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("PLATILLO REGISTRADO CORRECTAMENTE");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int disp;

            if (chkDisp.Checked)
            {
                disp = 1;
            }
            else
            {
                disp = 0;
            }

            conexion.Open();

            string Query = "UPDATE platillos SET NOMBRE='" + txtNom.Text + "',PRECIO='" + txtprecio.Text + "',DISPONIBLE='" + disp + "',CATEGORIAID='" + txtCateg.Text + "'WHERE ID='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("LOS DATOS SE HAN ACTUALIZADO CORRECTAMENTE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string Query = "DELETE FROM platillos WHERE ID='" + txtId.Text + "';";
            MySqlCommand comando = new MySqlCommand(Query, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("PLATILLO ELIMINADO CON EXITO");
        }
    }
}
