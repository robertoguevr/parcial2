using parcial2.VISTAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using parcial2.MODEL;

namespace parcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLoguin log = new frmLoguin();
            log.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                var lista = from usuario in db.usuarios
                            where usuario.dui == txtConsulta.Text
                            select usuario;

                if (lista.Count() > 0)
                {
                    var nombre = from usuario in db.usuarios
                                 where usuario.dui == txtConsulta.Text
                                 select new
                                 {
                                     Nombre = usuario.nombre.ToString()
                                 };
                    foreach (var iterarnomnbre in nombre)
                    {
                        lblNombre.Text = iterarnomnbre.Nombre.ToString();

                        lblNombre.Visible = true;
                        lblBeneficiario.Visible = true;
                    }
                }
                else
                {
                    lblNombre.Text = "NO ERES BENEFICIARIO";
                    lblNombre.Visible = true;
                    lblBeneficiario.Visible = false;
                }
            }
        }
    }
}