using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quieres cerrar el sistema","",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None)
                ==DialogResult.Yes);

            Environment.Exit(0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void txt_Nombre_Emp_Click(object sender, EventArgs e)
        {

        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
