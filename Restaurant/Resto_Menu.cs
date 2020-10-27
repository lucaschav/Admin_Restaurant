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
    public partial class Resto_Menu : Form
    {
        public Resto_Menu()
        {
            InitializeComponent();
        }


        private void AbrirFormHija(object formhija)
        {
            if (this.panelprincipal.Controls.Count > 0)
                this.panelprincipal.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelprincipal.Controls.Add(fh);
            this.panelprincipal.Tag = fh;
            fh.Show();
        }

        private void Resto_Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            AbrirFormHija(new Categ());
        }

        private void panelprincipal_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnPlatillos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Platillos());
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Reserva());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHija(new Ajustes());
        }
    }
}
