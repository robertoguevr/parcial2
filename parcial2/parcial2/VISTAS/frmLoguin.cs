using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace parcial2.VISTAS
{
    public partial class frmLoguin : Form
    {
        public frmLoguin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("master") && txtPass.Text.Equals("123"))
            {
                frmAdmin admin = new frmAdmin();
                admin.Show();
            }
            else 
            {
                MessageBox.Show("Usuario incorrecto");
            }
        }
    }
}
