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

namespace parcial2.VISTAS
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        usuarios user = new usuarios();
        void cargardatos() 
        {
            using (gobEntities bd = new gobEntities())
            {
                dtvUsuarios.DataSource = bd.usuarios.ToList();
            }
               
        }

        void limpiardatos() 
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDui.Text = "";
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (gobEntities bd = new gobEntities())
            {
                
                user.id = Convert.ToInt32(txtId.Text);
                user.nombre = txtNombre.Text;
                user.dui = txtDui.Text;

                bd.usuarios.Add(user);
                bd.SaveChanges();

            }
            cargardatos();
            limpiardatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (gobEntities bd = new gobEntities())
            {
                string Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();

                user = bd.usuarios.Find(int.Parse(Id));
                bd.usuarios.Remove(user);
                bd.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (gobEntities db = new gobEntities())
            {
                string Id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();
                int IdC = int.Parse(Id);
                user = db.usuarios.Where(VerificarId => VerificarId.id == IdC).First();
                user.id = Convert.ToInt32(txtId.Text);
                user.nombre = txtNombre.Text;
                user.dui = txtDui.Text;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            cargardatos();
            limpiardatos();
        }
    }
}
