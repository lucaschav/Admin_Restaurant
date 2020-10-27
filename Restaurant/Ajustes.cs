using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient;

namespace Restaurant
{
    public partial class Ajustes : Form
    {
        public Ajustes()
        {
            InitializeComponent();
        }

        public static List<string> datos_conect = new List<string>();

        private void btnReserva_Click(object sender, EventArgs e)
        {
            TextWriter arch = new StreamWriter("DBConfig.txt");
            arch.Close();

            TextWriter archivo = File.AppendText("DBConfig.txt");

            archivo.WriteLine(txtNameSv.Text);
            archivo.WriteLine(txtNameDB.Text);
            archivo.WriteLine(txtUid.Text);
            archivo.WriteLine(txtPass.Text);

            MessageBox.Show("DATOS GUARDADOS CON EXITO");

            archivo.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextWriter archivo = new StreamWriter("DBConfig.txt");
            archivo.Close();
            MessageBox.Show("Se eliminaron los datos con exito");
        }

        private void Ajustes_Load(object sender, EventArgs e)
        {
            
        }

        private void txtNameSv_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string aux;

            StreamReader leer = File.OpenText("DBConfig.txt");

            datos_conect.Clear();

            while (!leer.EndOfStream)
            {

                aux = leer.ReadLine();

                datos_conect.Add(aux);

            }

            leer.Close();

            try
            {
                txtNameSv.Text = datos_conect[0].ToString();
                txtNameDB.Text = datos_conect[1].ToString();
                txtUid.Text = datos_conect[2].ToString();
                txtPass.Text = datos_conect[3].ToString();
            }
            catch
            {
                MessageBox.Show("NO HAY DATOS PARA CARGAR");
            }
        }    

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection("Server=" + txtNameSv.Text + ";" + "Database=" + txtNameDB.Text + ";" + "Uid=" + txtUid.Text + ";"+ "Pwd=" + txtPass.Text +"");

            try
            {
                conexion.Open();

                MessageBox.Show("Conectado");

                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Error al conectarse al servidor");
            }

        }

    }
}
